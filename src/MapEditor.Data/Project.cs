using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.Encoding;
using MapEditor.Data.Actions;
using MapEditor.Data.TileLogicNew;

namespace MapEditor.Data {
	public class Project : IEncodable {
		public string RegionName, RegionAuthor;
		public List<Map> Maps = new List<Map>();
		public TreeView lMaps = new TreeView();
		public TreeNode RootNode = new TreeNode();
		public List<TileLogicScript> Logics = new List<TileLogicScript>();
		public World World;

		public static Project CurrentProject {
			get {
				Project proj = new Project();
				proj.World = EditorEngine.Instance.World;
				proj.Maps = EditorEngine.Instance.World.Maps;
				return proj;
			}
		}

		public void Save(string loc, TreeView mapstree) {
			Project proj = CurrentProject;
			proj.lMaps = mapstree;
			EncoderUtil.Encode(loc, proj);
		}

		public static Project Load(string loc) {
			return EncoderUtil.Decode<Project>(loc);
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(World.Name);
			stream.Write(World.Author ?? "");

			World.TilesetContainer.Encode(stream);
			World.EntityContainer.Encode(stream);
			World.EntityTemplateFactory.Encode(stream);
			World.TilesetFactory.Encode(stream);
			World.UIContainer.Encode(stream);
			World.SpriteLibrary.Encode(stream);

			//DFS
			Stack<TreeNode> stack = new Stack<TreeNode>();
			List<TreeNode> visited = new List<TreeNode>();

			List<TreeNode> _reversed = lMaps.Nodes[0].Nodes.Cast<TreeNode>().ToList();
			_reversed.Reverse();
			foreach (TreeNode child in _reversed) {
				stack.Push(child);
			}

			//OPCODES:
			//0x01 : FOLDER
			//0x02 : FALL-IN
			//0x03 : FALL-BACK
			//0x04 : MAP

			int writeCount = 0;

			Stack<TreeNode> _stack = new Stack<TreeNode>();

			_reversed.Clear();
			_reversed = lMaps.Nodes[0].Nodes.Cast<TreeNode>().ToList();
			_reversed.Reverse();
			foreach (TreeNode child in _reversed) {
				_stack.Push(child);
			}

			while (_stack.Count > 0) {
				TreeNode node = _stack.Pop();
				writeCount++;
				List<TreeNode> reversed = node.Nodes.Cast<TreeNode>().ToList();
				reversed.Reverse();
				if (reversed.Count > 0)
					writeCount += 2;
				foreach (TreeNode child in reversed) {
					_stack.Push(child);
				}
			}

			stream.Write(writeCount);

			while (stack.Count > 0) {
				TreeNode node = stack.Pop();
				Map m = node.Tag as Map;
				visited.Add(node);
				if (m == null) {
					stream.Write(0x01);
					stream.Write(node.Text);
					List<TreeNode> reversedChilds = node.Nodes.Cast<TreeNode>().ToList();
					reversedChilds.Reverse();
					if (reversedChilds.Count > 0)
						stream.Write(0x02);
					foreach (TreeNode child in reversedChilds)
						stack.Push(child);
				} else {
					stream.Write(0x04);

					stream.Write(m.Name);
					stream.Write(m.Author);
					stream.Write(m.Width);
					stream.Write(m.Height);

					/* ENCODE ALL MOCKUP TILESETS */
					stream.Write(m.Tilesets.Count);
					foreach (MockupTileset tref in m.Tilesets) {
						stream.Write(tref.Tileset.Name);
					}

					/* ENCODE ALL MOCKUP BEHAVIORS */
					for (int i = 0; i < m.Width * m.Height; i++) {
						int x = i % m.Width;
						int y = i / m.Width;

						m.Behaviors[x, y].Encode(stream);
					}

					/* ENCODE ALL ACTIONS */
					ActionManager actionmanager = EditorEngine.Instance.GetActionManager(m);
					ActionIO writer = new ActionIO(stream);

					stream.Write(actionmanager.Actions.Count);
					foreach (IAction act in actionmanager.Actions) {
						writer.Write(act);
					}
				}

				if (node.Parent != null && lMaps.Nodes[0].Nodes[lMaps.Nodes[0].Nodes.Cast<TreeNode>().Count() - 1] != node) {
					bool allDone = true;
					foreach (TreeNode child in node.Parent.Nodes) {
						bool done = false;
						foreach (TreeNode visitedNode in visited.Where(visitedNode => child.Equals(visitedNode))) {
							done = true;
						}
						if (!done) {
							allDone = false;
							break;
						}
					}
					if (allDone) {
						stream.Write(0x03);
					}
				}
			}
		}

		public IEncodable Decode(BinaryInput stream) {
			stream.GraphicsDevice = EditorEngine.Instance.GraphicsDevice;

			RegionName = stream.ReadString();
			RegionAuthor = stream.ReadString();

			World world = EditorEngine.Instance.CreateRegion(RegionName);

			world.TilesetContainer.Decode(stream);
			world.EntityContainer.Decode(stream);
			world.EntityTemplateFactory.Decode(stream);
			world.TilesetFactory.Decode(stream);
			world.UIContainer.Decode(stream);
			world.SpriteLibrary.Decode(stream);

			this.RootNode = new TreeNode(RegionName);
			TreeNode lastNode = null;
			TreeNode currentNode = RootNode;

			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				int code = stream.ReadInt32();
				switch (code) {
					case 0x01:
						string text = stream.ReadString();
						TreeNode node = new TreeNode(text);
						currentNode.Nodes.Add(node);
						lastNode = node;
						break;
					case 0x02:
						currentNode = lastNode;
						break;
					case 0x03:
						currentNode = currentNode.Parent;
						break;
					case 0x04:
						/*RECREATE FROM DETAILS*/
						Map m = new Map(EditorEngine.Instance.World.EntityFactory);

						m.Name = stream.ReadString();
						m.Author = stream.ReadString();
						m.Width = stream.ReadInt32();
						m.Height = stream.ReadInt32();

						m.Tiles = new MockupTile[m.Width][][];
						for (int x = 0; x < m.Width; x++) {
							m.Tiles[x] = new MockupTile[m.Height][];
							for (int y = 0; y < m.Height; y++) {
								m.Tiles[x][y] = new MockupTile[Map.LayerCount];
							}
						}

						/* READ ALL MOCKUP TILESETS */
						int c1 = stream.ReadInt32();
						for (int j = 0; j < c1; j++) {
							string name = stream.ReadString();
							m.Tilesets.Add(new MockupTileset(world, EditorEngine.Instance.GetTilesetIndexByName(name)));
						}

						m.Fill(-1, 0);

						Map oldCurrentMap = EditorEngine.Instance.CurrentMap;

						EditorEngine.Instance.CurrentMap = m;

						List<byte> visited = new List<byte>();

						/* READ MOCKUP TILE BEHAVIORS */
						m.Behaviors = new MockupTileBehavior[m.Width,m.Height];
						for (int j = 0; j < m.Width * m.Height; j++) {
							int x = j % m.Width;
							int y = j / m.Height;

							m.Behaviors[x, y] = stream.ReadObject<MockupTileBehavior>();
						}

						/* READ ACTIONS/REBUILD MAP */
						ActionManager actionmanager = EditorEngine.Instance.GetActionManager();
						ActionIO reader = new ActionIO(stream);

						int c2 = stream.ReadInt32();
						for (int j = 0; j < c2; j++) {
							IAction act = reader.Read();
							actionmanager.Execute(act);
						}

						/*DATA TREE NODE*/
						TreeNode node2 = new TreeNode(m.Name);
						node2.Tag = m;
						node2.ImageKey = "document.png";
						node2.SelectedImageKey = "document.png";

						if (currentNode != null) currentNode.Nodes.Add(node2);
						else Console.WriteLine("WARNING: CurrentNode is null (Project.Decode)");

						EditorEngine.Instance.CurrentMap = oldCurrentMap;
						break;
				}
			}
			return this;
		}
	}
}
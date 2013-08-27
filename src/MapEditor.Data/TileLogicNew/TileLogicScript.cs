using System;
using System.Collections.Generic;
using System.IO;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using General.Script;
using MapEditor.Data.Actions.Tile;

namespace MapEditor.Data.TileLogicNew {
	public class TileLogicScript {
		public string name, s_0;
		public int index;
		public int s_1;
		public List<Tuple<string, int>> sameTypes;
		public SharpScript script;

		public TileLogicScript(int index) {
			sameTypes = new List<Tuple<string, int>>();
			this.index = index;
		}

		public void Load(string loc) {
			script = new SharpScript();
			try {
				string location = Environment.CurrentDirectory + "\\Scripts\\Logic\\" + loc + (loc.EndsWith(".cs") ? "" : ".cs");
				name = loc.Split('0')[0];
				string code = File.ReadAllText(location);
				script.CompileCode(code);
				script.Invoke("Load", this);
				Console.WriteLine("s_0: " + s_0);
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("-- Error (" + e.GetType() + "): " + e.Message);
				Console.ResetColor();
			}
		}

		public SetTileAction Evaluate(int x, int y) {
			try {
				MockupTile tu = EditorEngine.Instance.CurrentMap.GetTile(x, y - 1, EditorEngine.Instance.SelectedLayer);
				MockupTile td = EditorEngine.Instance.CurrentMap.GetTile(x, y + 1, EditorEngine.Instance.SelectedLayer);
				MockupTile tl = EditorEngine.Instance.CurrentMap.GetTile(x - 1, y, EditorEngine.Instance.SelectedLayer);
				MockupTile tr = EditorEngine.Instance.CurrentMap.GetTile(x + 1, y, EditorEngine.Instance.SelectedLayer);
				MockupTile tul = EditorEngine.Instance.CurrentMap.GetTile(x - 1, y - 1, EditorEngine.Instance.SelectedLayer);
				MockupTile tur = EditorEngine.Instance.CurrentMap.GetTile(x + 1, y - 1, EditorEngine.Instance.SelectedLayer);
				MockupTile tdl = EditorEngine.Instance.CurrentMap.GetTile(x - 1, y + 1, EditorEngine.Instance.SelectedLayer);
				MockupTile tdr = EditorEngine.Instance.CurrentMap.GetTile(x + 1, y + 1, EditorEngine.Instance.SelectedLayer);

				bool u = isSameType(tu);
				bool d = isSameType(td);
				bool l = isSameType(tl);
				bool r = isSameType(tr);
				bool ul = isSameType(tul);
				bool ur = isSameType(tur);
				bool dl = isSameType(tdl);
				bool dr = isSameType(tdr);

				LogicEvalInfo _info = new LogicEvalInfo("", 0);
				script.Invoke("Eval", this, _info, u, d, l, r, ul, ur, dl, dr);

				int zt = EditorEngine.Instance.SelectedLayer;
				MockupTile t = EditorEngine.Instance.CurrentMap.GetTile(x, y, zt);
				if (t == null) return null;

				SetTileAction act = new SetTileAction(x, y, zt, EditorEngine.Instance.World.TilesetContainer.IndexOf(EditorEngine.Instance.GetTilesetByName(_info.s1)), _info.s2);

				return act;
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("-- Error (" + e.GetType() + "): " + e.Message);
				//GameConsole.WriteLine("Info: " + e.Value.Value);
				Console.WriteLine("\r\n\r\n");
				Console.ResetColor();
			}
			return null;
		}

		public void addSameType(string i1, int i2) {
			sameTypes.Add(new Tuple<string, int>(i1, i2));
		}

		public void addSameType(string i0, int i1, int i2) {
			int index = EditorEngine.Instance.GetTilesetByName(i0).Texture.GetIndex(i1, i2);
			sameTypes.Add(new Tuple<string, int>(i0, index));
		}

		public bool isSameType(MockupTile t) {
			if (t == null) return false;
			return isSameType(new Tuple<string, int>(t.Tileset.Name, t.tileIndex));
		}

		public bool isSameType(Tuple<string, int> t) {
			return sameTypes.Contains(t);
		}
	}
}
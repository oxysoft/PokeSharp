using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.Extensions;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions;
using MapEditor.Data.Actions.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.States.TileEditor {
	public class BucketTool : State, IState {
		public static BucketTool Instance {
			get { return Static<BucketTool>.Value; }
		}

		public string Name {
			get { return "BucketState"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.EditorForm.b_bucket.Checked = true;
			this.EditorForm.editorcontrol.MouseDown += onMouseDown;
			this.EditorForm.editorcontrol.MouseMove += onMouseMove;
		}

		private void onMouseMove(object sender, MouseEventArgs e) {
			int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
			int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);

			this.lxt = xt;
			this.lyt = yt;
		}

		private void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);

				int z = TileEditorState.Instance.SelectedLayer;
				int tilesetIndex = TileEditorState.Instance.SelectedTileset;

				Rectangle selectedRegion = TileEditorState.Instance.SelectedRegion;
				Tileset tileset = EditorEngine.Instance.CurrentMap.Tilesets[tilesetIndex].Tileset;

				int tileIndex = tileset.Texture.GetIndex(selectedRegion.X, selectedRegion.Y);

				FillAction fillAction = new FillAction(xt, yt, tileIndex, tilesetIndex);
				EditorEngine.Instance.GetActionManager().Execute(fillAction);
				foreach (SetTileAction a in fillAction.Actions) {
					Map map = EditorEngine.Instance.CurrentMap;

					MockupTileBehavior b = map.GetBehavior(a.X, a.Y);
					b.BehaviorId = map.Tilesets[a.TilesetIndex].Tileset.Tiles[a.TileIndex].DefaultBehavior.BehaviorId;
				}
			}
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			this.EditorForm.b_bucket.Checked = false;
			this.EditorForm.editorcontrol.MouseDown -= onMouseDown;
			this.EditorForm.editorcontrol.MouseMove -= onMouseMove;
		}

		private int lxt, lyt;

		public void Draw(GameTime gameTime) {
			Map map = EditorEngine.Instance.CurrentMap;
			if (lxt < 0 || lyt < 0 || lxt >= map.Width || lyt >= map.Height) return;
			Tileset tileset = EditorEngine.Instance.CurrentMap.Tilesets[TileEditorState.Instance.SelectedTileset].Tileset;
			Stack<Vector2> visitStack = new Stack<Vector2>();
			List<Vector2> visited = new List<Vector2>();
			List<Vector2> points = new List<Vector2>();

			visitStack.Push(new Vector2(lxt, lyt));

			int currentIndex = map.GetTile(lxt, lyt, EditorEngine.Instance.SelectedLayer).tileIndex;
			int currentTilesetIndex = map.GetTile(lxt, lyt, EditorEngine.Instance.SelectedLayer).tilesetIndex;

			while (visitStack.Count > 0) {
				Vector2 point = visitStack.Pop();

				if (!visited.Contains(point)) {
					int cx = (int) point.X;
					int cy = (int) point.Y;

					MockupTile t = EditorEngine.Instance.CurrentMap.GetTile(cx, cy, EditorEngine.Instance.SelectedLayer);

					points.Add(point);

					if (map.GetTile(cx + 1, cy, EditorEngine.Instance.SelectedLayer) != null && cx + 1 < map.Width && map.GetTile(cx + 1, cy, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx + 1, cy, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
						visitStack.Push(new Vector2(cx + 1, cy));
					if (map.GetTile(cx - 1, cy, EditorEngine.Instance.SelectedLayer) != null && cx - 1 >= 0 && map.GetTile(cx - 1, cy, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx - 1, cy, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
						visitStack.Push(new Vector2(cx - 1, cy));
					if (map.GetTile(cx, cy + 1, EditorEngine.Instance.SelectedLayer) != null && cy + 1 < map.Width && map.GetTile(cx, cy + 1, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx, cy + 1, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
						visitStack.Push(new Vector2(cx, cy + 1));
					if (map.GetTile(cx, cy - 1, EditorEngine.Instance.SelectedLayer) != null && cy - 1 < map.Width && map.GetTile(cx, cy - 1, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx, cy - 1, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
						visitStack.Push(new Vector2(cx, cy - 1));

					visited.Add(point);
				}
			}

			SpriteBatch spriteBatch = EditorEngine.Instance.World.ViewData.SpriteBatch;

			foreach (Vector2 point in points) {
				Rectangle target = new Rectangle((int) (point.X * 16 * EditorEngine.Instance.World.Camera.Scale), (int) (point.Y * 16 * EditorEngine.Instance.World.Camera.Scale), (int) (16 * EditorEngine.Instance.World.Camera.Scale), (int) (16 * EditorEngine.Instance.World.Camera.Scale));
				Rectangle source = tileset.Texture.GetSource(TileEditorState.Instance.SelectedRegion.X, TileEditorState.Instance.SelectedRegion.Y);
				spriteBatch.Draw(tileset.Texture.Texture, target.Add(EditorEngine.Instance.World.Camera.Location), source, Color.Black * .5f);
			}
		}

		public void Update(GameTime gameTime) {
		}
	}
}
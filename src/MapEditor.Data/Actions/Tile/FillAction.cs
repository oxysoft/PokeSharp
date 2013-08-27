using System;
using System.Collections.Generic;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using Microsoft.Xna.Framework;

namespace MapEditor.Data.Actions.Tile {
	public class FillAction : MultiAction, IAction {

		int x, y;
		int tileindex, tilesetindex;

		public FillAction() {
		}

		public FillAction(int x, int y, int tileindex, int tilesetindex) {
			this.x = x;
			this.y = y;
			this.tileindex = tileindex;
			this.tilesetindex = tilesetindex;
		}

		public new string Name {
			get {
				return "Tile Fill";
			}
		}

		public new DateTime Time {
			get;
			set;
		}

		public override void Execute() {
			Map map = EditorEngine.Instance.CurrentMap;

			if (x >= 0 && x < map.Width && y >= 0 && y < map.Height) {
				int currentIndex = map.GetTile(x, y, EditorEngine.Instance.SelectedLayer).tileIndex;
				int currentTilesetIndex = map.GetTile(x, y, EditorEngine.Instance.SelectedLayer).tilesetIndex;

				Stack<Vector2> pp = new Stack<Vector2>();
				List<Vector2> hpp = new List<Vector2>();

				pp.Push(new Vector2(x, y));

				while (pp.Count > 0) {
					Vector2 cp = pp.Pop();

					if (!hpp.Contains(cp)) {
						int cx = (int)cp.X;
						int cy = (int)cp.Y;

						MockupTile t = EditorEngine.Instance.CurrentMap.GetTile(cx, cy, EditorEngine.Instance.SelectedLayer);
						SetTileAction ta = new SetTileAction(cx, cy, EditorEngine.Instance.SelectedLayer, tilesetindex, tileindex);

						Actions.Add(ta);

						if (map.GetTile(cx + 1, cy, EditorEngine.Instance.SelectedLayer) != null && cx + 1 < map.Width && map.GetTile(cx + 1, cy, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx + 1, cy, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
							pp.Push(new Vector2(cx + 1, cy));
						if (map.GetTile(cx - 1, cy, EditorEngine.Instance.SelectedLayer) != null && cx - 1 >= 0 && map.GetTile(cx - 1, cy, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx - 1, cy, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
							pp.Push(new Vector2(cx - 1, cy));
						if (map.GetTile(cx, cy + 1, EditorEngine.Instance.SelectedLayer) != null && cy + 1 < map.Width && map.GetTile(cx, cy + 1, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx, cy + 1, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
							pp.Push(new Vector2(cx, cy + 1));
						if (map.GetTile(cx, cy - 1, EditorEngine.Instance.SelectedLayer) != null && cy - 1 < map.Width && map.GetTile(cx, cy - 1, EditorEngine.Instance.SelectedLayer).tileIndex == currentIndex && map.GetTile(cx, cy - 1, EditorEngine.Instance.SelectedLayer).tilesetIndex == currentTilesetIndex)
							pp.Push(new Vector2(cx, cy - 1));

						hpp.Add(cp);
					}
				}
			}
			base.Execute();
		}
	}
}

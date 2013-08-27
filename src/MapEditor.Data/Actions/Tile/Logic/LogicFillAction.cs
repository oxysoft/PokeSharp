using System.Collections.Generic;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using MapEditor.Data.TileLogicNew;
using Microsoft.Xna.Framework;

namespace MapEditor.Data.Actions.Tile.Logic {
	public class LogicFillAction : MultiAction, IAction {

		int xt, yt;
		int logicindex;
		bool sametype;

		public LogicFillAction(int xt, int yt, int logicindex, bool sametype) {
			this.xt = xt;
			this.yt = yt;
			this.logicindex = logicindex;
			this.sametype = sametype;
		}

		public override string Name {
			get {
				return "Logic Fill";
			}
		}

		public override void Execute() {
			Stack<Vector2> stack = new Stack<Vector2>();
			List<Vector2> visited = new List<Vector2>();

			stack.Push(new Vector2(xt, yt));

			MockupTile mockup = EditorEngine.Instance.CurrentMap.GetTile(xt, yt, EditorEngine.Instance.SelectedLayer);

			if (mockup != null) {
				string tilesheetindex = mockup.Tileset.Name;
				int tileindex = mockup.tileIndex;

				TileLogicScript sc = null;
				if (sametype) {
					sc = TileLogicManager.Instance.getLogicFromSameType(tilesheetindex, tileindex);
				}


				int i = 0;

				while (stack.Count > 0) {
					Vector2 pop = stack.Pop();

					if (!visited.Contains(pop)) {
						int x = (int)pop.X;
						int y = (int)pop.Y;

						MockupTile u = EditorEngine.Instance.CurrentMap.GetTile(x, y - 1, EditorEngine.Instance.SelectedLayer);
						MockupTile d = EditorEngine.Instance.CurrentMap.GetTile(x, y + 1, EditorEngine.Instance.SelectedLayer);
						MockupTile l = EditorEngine.Instance.CurrentMap.GetTile(x - 1, y, EditorEngine.Instance.SelectedLayer);
						MockupTile r = EditorEngine.Instance.CurrentMap.GetTile(x + 1, y, EditorEngine.Instance.SelectedLayer);

						if (sametype && sc != null) {
							if (u != null && TileLogicManager.Instance.getLogicFromSameType(u.Tileset.Name, u.tileIndex) == sc) stack.Push(new Vector2(x, y - 1));
							if (d != null && TileLogicManager.Instance.getLogicFromSameType(d.Tileset.Name, d.tileIndex) == sc) stack.Push(new Vector2(x, y + 1));
							if (l != null && TileLogicManager.Instance.getLogicFromSameType(l.Tileset.Name, l.tileIndex) == sc) stack.Push(new Vector2(x - 1, y));
							if (r != null && TileLogicManager.Instance.getLogicFromSameType(r.Tileset.Name, r.tileIndex) == sc) stack.Push(new Vector2(x + 1, y));
						} else {
							if (u != null && (u.Tileset.Name == tilesheetindex && u.tileIndex == tileindex)) stack.Push(new Vector2(x, y - 1));
							if (d != null && d.Tileset.Name == tilesheetindex && d.tileIndex == tileindex) stack.Push(new Vector2(x, y + 1));
							if (l != null && l.Tileset.Name == tilesheetindex && l.tileIndex == tileindex) stack.Push(new Vector2(x - 1, y));
							if (r != null && r.Tileset.Name == tilesheetindex && r.tileIndex == tileindex) stack.Push(new Vector2(x + 1, y));
						}

						this.Actions.Add(new LogicSetAction(x, y, logicindex, false));
						i++;
						visited.Add(pop);
					}
				}
			}

			base.Execute();
			
			foreach (Vector2 vec2 in visited) {
				int xr = (int)vec2.X;
				int yr = (int)vec2.Y;

				new LogicSetAction(xr, yr, logicindex).Execute();
			}
		}
	}
}

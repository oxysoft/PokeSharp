using System;
using System.Collections.Generic;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using MapEditor.Data.TileLogicNew;

namespace MapEditor.Data.Actions.Tile.Logic {
	public class LogicSetAction : MultiAction, IAction {

		int xt, yt;
		int logicindex;
		bool updateneighbors = true;

		public LogicSetAction(int xt, int yt, int logicindex) {
			this.xt = xt;
			this.yt = yt;
			this.logicindex = logicindex;
		}

		public LogicSetAction(int xt, int yt, int logicindex, bool updateneighbors) {
			this.xt = xt;
			this.yt = yt;
			this.logicindex = logicindex;
			this.updateneighbors = updateneighbors;
		}

		public new string Name {
			get {
				return "Logic Set tile";
			}
		}

		public new DateTime Time {
			get;
			set;
		}

		public void FillList() {
			if (logicindex >= 0) {
				SetTileAction action = TileLogicManager.Instance.logics[logicindex].Evaluate(xt, yt);
				if (action != null) {
					action.Execute();
				}

				if (updateneighbors) {
					List<MockupTile> neighbors = new List<MockupTile>();
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt - 1, yt - 1, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt, yt - 1, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt + 1, yt - 1, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt - 1, yt, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt, yt, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt + 1, yt, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt - 1, yt + 1, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt, yt + 1, EditorEngine.Instance.SelectedLayer));
					neighbors.Add(EditorEngine.Instance.CurrentMap.GetTile(xt + 1, yt + 1, EditorEngine.Instance.SelectedLayer));

					//sometime the ugliest solution is the best
					List<Tuple<int, int>> positions = new List<Tuple<int, int>>();
					positions.Add(new Tuple<int, int>(-1, -1));
					positions.Add(new Tuple<int, int>(0, -1));
					positions.Add(new Tuple<int, int>(+1, -1));
					positions.Add(new Tuple<int, int>(-1, 0));
					positions.Add(new Tuple<int, int>(0, 0));
					positions.Add(new Tuple<int, int>(+1, 0));
					positions.Add(new Tuple<int, int>(-1, +1));
					positions.Add(new Tuple<int, int>(0, +1));
					positions.Add(new Tuple<int, int>(+1, +1));

					int i = 0;
					foreach (MockupTile neighbor in neighbors) {
						if (neighbor != null) {
							if (TileLogicManager.Instance.logics[logicindex].isSameType(neighbor)) {
								if (Options.Instance.LogicCorrectSameType) {
									SetTileAction _action = TileLogicManager.Instance.logics[logicindex].Evaluate(xt + positions[i].Item1, yt + positions[i].Item2);
									if (_action != null) this.Actions.Add(_action);
								}
							} else {
								if (Options.Instance.LogicCorrectOtherType) {
									TileLogicScript logic = TileLogicManager.Instance.getLogicFromSameType(neighbor.Tileset.Name, neighbor.tileIndex);
									if (logic != null) {
										SetTileAction _action = TileLogicManager.Instance.logics[logic.index].Evaluate(xt + positions[i].Item1, yt + positions[i].Item2);
										if (_action != null) this.Actions.Add(_action);
									}
								}
							}
						}
						i++;
					}
				}
				if (action != null) {
					action.UnExecute();
					Actions.Add(action);
				}
			}
		}

		public override void Execute() {
			FillList();
			base.Execute();
		}
	}
}

using System;
using System.Collections.Generic;

namespace MapEditor.Data.Actions.Tile.Logic {
	public class LogicPathAction : MultiAction, IAction {

		int logicindex;
		int size;
		private List<LogicPathSquare> squares;

		public LogicPathAction(List<LogicPathSquare> squares, int logicindex, int size) {
			this.squares = squares;
			this.logicindex = logicindex;
			this.size = size;
		}

		public override string Name {
			get {
				return "Logic Path";
			}
		}

		public override void Execute() {
			foreach (LogicPathSquare sq in squares) {

				int x0 = 0 - (int) (Math.Floor((double) size / 2));
				int x1 = 0 + (int) (Math.Floor((double) size / 2));

				for (int i = x0; i <= x1; i++) {
					Actions.Add(new LogicSetAction(sq.x + (sq.dir == 0 || sq.dir == 1 ? -i : 0), sq.y + (sq.dir == 2 || sq.dir == 3 ? -i : 0), logicindex));
				}
				//actions.Add(new LogicSetAction(sq.x + (sq.dir == 0 || sq.dir == 1 ? -i : 0), sq.y + (sq.dir == 2 || sq.dir == 3 ? -i : 0), logicindex));
				//actions.Add(new LogicSetAction(sq.x, sq.y, logicindex));
				//actions.Add(new LogicSetAction(sq.x + (sq.dir == 0 || sq.dir == 1 ? i : 0), sq.y + (sq.dir == 2 || sq.dir == 3 ? i : 0), logicindex));
			}

			base.Execute();
		}

	}
}

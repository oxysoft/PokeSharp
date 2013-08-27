using GameEngine.Data.Common;
using Microsoft.Xna.Framework;

namespace MapEditor.Data.Actions.Tile.Logic {
	public class LogicRectangleAction : MultiAction, IAction {

		public LogicRectangleAction(Rectangle source, int logicindex) {
			this.source = source;
			this.logicindex = logicindex;
		}

		Rectangle source;
		int logicindex;

		public override string Name {
			get {
				return "Logic Set";
			}
		}

		public override void Execute() {
			Map map = EditorEngine.Instance.CurrentMap;

			if (source.Width > 0 && source.Height > 0) {
				int sx = 0;
				int sy = 0;

				for (int x = 0; x < source.Width; x++) {
					if (x % source.Width == 0) {
						sx = 0;
					}
					for (int y = 0; y < source.Height; y++) {
						if (y % source.Height == 0) {
							sy = 0;
						}

						LogicSetAction ta = new LogicSetAction(source.X + x, source.Y + y, logicindex);
						Actions.Add(ta);
						sy++;
					}
					sx++;
				}
			}

			base.Execute();
		}

	}
}

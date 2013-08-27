using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using Microsoft.Xna.Framework;

namespace MapEditor.Data.Actions.Tile {
	public class RectangleAction : MultiAction, IAction {

		public RectangleAction() {
		}

		public RectangleAction(Rectangle source, Rectangle target, int tilesetindex) {
			this.source = source;
			this.target = target;
			this.tilesetindex = tilesetindex;
		}

		Rectangle source, target;
		int tilesetindex;

		public override string Name {
			get {
				return "Tile Set";
			}
		}

		public override void Execute() {
			Map map = EditorEngine.Instance.CurrentMap;
			Tileset tileset = map.Tilesets[tilesetindex].Tileset;

			if (source.Width > 0 && source.Height > 0) {
				int sx = 0;
				int sy = 0;

				for (int x = 0; x < target.Width; x++) {
					if (x % source.Width == 0) {
						sx = 0;
					}
					for (int y = 0; y < target.Height; y++) {
						if (y % source.Height == 0) {
							sy = 0;
						}

						int xt = target.X + x;
						int yt = target.Y + y;
						int zt = EditorEngine.Instance.SelectedLayer;

						MockupTile t = EditorEngine.Instance.CurrentMap.GetTile(xt, yt, zt);

						if (t != null) {
							SetTileAction ta = new SetTileAction(target.X + x, target.Y + y, zt, tilesetindex, tileset.Texture.GetIndex(source.X + sx, source.Y + sy));
							Actions.Add(ta);
							sy++;
						}
					}
					sx++;
				}
			}

			base.Execute();
		}

	}
}

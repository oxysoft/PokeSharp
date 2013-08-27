namespace MapEditor.Data.Controls.EditorView {
	public class ControlAssembledMaps : GameControl {
/*
		public override void Initialize() {
			List<Map> Maps = new List<Map>();
			EditorEngine.Instance.World.Maps.ForEach(m => Maps.Add(m));

			//we may need this in the future, so we keep it

			Map farup;
			Map fardown;
			Map farleft;
			Map farright;

			int xmin, ymin, xmax, ymax;
			xmin = ymin = xmax = ymax = 0;

			foreach (Map m in Maps) {
				if (m.WorldPosition.X < xmin) {
					xmin = (int)m.WorldPosition.X;
					farleft = m;
				}
				if (m.WorldPosition.X > xmax) {
					xmax = (int)m.WorldPosition.X;
					farright = m;
				}
				if (m.WorldPosition.X < ymin) {
					ymin = (int)m.WorldPosition.Y;
					farup = m;
				}
				if (m.WorldPosition.X < ymax) {
					ymax = (int)m.WorldPosition.Y;
					fardown = m;
				}
			}

			base.Initialize();
		}

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			base.Update(gameTime);
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			List<Map> Maps = EditorEngine.Instance.World.Maps;
			SpriteBatch batch = EditorEngine.Instance.World.ViewData.SpriteBatch;

			int spacing = 1;
			int xs = 32;
			int ys = 32;
			int Width = 8;
			int Height = 8;
			Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);

			batch.Begin();

			int it = 0;

			foreach (Map m in Maps) {
				int xt = xs + ((int)m.WorldPosition.X * 8) + (spacing * it);
				int yt = ys + ((int)m.WorldPosition.Y * 8) + (spacing * it);

				for (int y = 0; y < Height; y++) {
					for (int x = 0; x < Width; x++) {
						batch.Draw(pixel, new Rectangle(xt + x, yt + y, 1, 1), Color.Black);
					}
				}
				it++;
			}
			batch.End();

			base.Draw(gameTime);
		}*/
	}
}

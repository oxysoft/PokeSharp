using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Entities.Types;
using GameEngine.Data.Text.Fonts;
using General.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Scripting.UserInterface {
	public class InterfaceInteraction : PlayerInteraction {
		private SpriteBatch spriteBatch;
		public UI Ui;

		public int GameWidth {
			get { return GameEngine.WIDTH; }
		}

		public int GameHeight {
			get { return GameEngine.HEIGHT; }
		}

		public InterfaceInteraction(UI ui, SpriteBatch spriteBatch, PlayerEntity player) : base(player) {
			this.spriteBatch = spriteBatch;
			this.Ui = ui;
		}

		public void DrawSprite(int x, int y, string location) {
			DrawSprite(x, y, location, 1f);
		}

		public void DrawSprite(int x, int y, string location, float opacity) {
			Texture2D sprite = this.player.World.SpriteLibrary.GetSprite(location);
			if (sprite != null) {
				spriteBatch.Draw(sprite, new Rectangle(x, y, sprite.Width, sprite.Height), Color.White * opacity);
			}
		}

		public void DrawSprite(int x, int y, string location, int columns, int rows, int xt, int yt) {
			DrawSprite(x, y, location, columns, rows, xt, yt, 1f);
		}

		public void DrawSprite(int x, int y, string location, int columns, int rows, int xt, int yt, float opacity) {
			Texture2D sprite = this.player.World.SpriteLibrary.GetSprite(location);
			if (sprite != null) {
				TileableTexture tileable = new TileableTexture(sprite, columns, rows);
				spriteBatch.Draw(sprite, new Rectangle(x, y, tileable.FrameWidth, tileable.FrameHeight), tileable.GetSource(tileable.GetIndex(xt, yt)), Color.White * opacity);
			}
		}

		public void DrawText(int x, int y, string s, int type) {
			FontRenderer.Instance.Draw(this.spriteBatch, s, type, x, y);
		}
	}
}
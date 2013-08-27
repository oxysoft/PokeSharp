using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GameEngine.Data.GameLoader;
using GameEngine.Data.Player;
using GameEngine.Data.Text.Fonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Data.Scenes {
	public enum MenuState {
		Animation,
		PressToStart,
		Interaction,
	}

	public class MenuScene : IScene {
		public SpriteBatch SpriteBatch { get; set; }
		public SceneState SceneState { get; set; }
		public MenuState MenuState;

		public MenuScene(GameData data, SpriteBatch spriteBatch) {
			this.SpriteBatch = spriteBatch;
			MenuState = MenuState.PressToStart;

			Boxes = new List<BoxInfo>();

			foreach (PlayerData playerData in data.Saves) {
				Boxes.Add(new BoxInfo("player '" + playerData.Name + "'", true));
			}

			Boxes.Add(new BoxInfo("correct:\ndid the cat escape\nthe old lady?", true));
			Boxes.Add(new BoxInfo("so\nvery fun time lots?", true));
			Boxes.Add(new BoxInfo("teststs", true));
		}

		private const int transitionTime = 100;
		private bool transitioning = false;
		private long KeyDownSpan = 0;

		public Texture2D InteractionPixelBG;
		public int Selection = 0;
		public List<BoxInfo> Boxes;

		public bool Pressed = false;

		public void Update(Microsoft.Xna.Framework.GameTime GameTime) {
			switch (MenuState) {
				case MenuState.Animation:
					break;
				case MenuState.PressToStart:
					if (Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.Enter) && !transitioning) {
						transitioning = true;
						KeyDownSpan = Environment.TickCount;
					}
					if (transitioning && Environment.TickCount - KeyDownSpan >= transitionTime) {
						transitioning = false;
						MenuState = MenuState.Interaction;
					}

					break;
				case MenuState.Interaction:
					bool up = Keyboard.GetState().IsKeyDown(Keys.Up);
					bool down = Keyboard.GetState().IsKeyDown(Keys.Down);
					bool A = Keyboard.GetState().IsKeyDown(Options.A) || Keyboard.GetState().IsKeyDown(Options.Start);

					if (up && !Pressed) {
						if (Selection - 1 >= 0) {
							Selection--;
							Pressed = true;
						}
					} else if (down && !Pressed) {
						if (Selection + 1 < Boxes.Count) {
							Selection++;
							Pressed = true;
						}
					}

					if (!up && !down) Pressed = false;

					if (A) {
						this.SceneState = SceneState.Dead;
					}

					break;
			}
		}

		public void Draw(Microsoft.Xna.Framework.GameTime GameTime) {
			/*if (SpriteBatch == null) {
				return;
			}*/

			/*Lazy Initialization*/
			if (InteractionPixelBG == null) {
				InteractionPixelBG = new Texture2D(SpriteBatch.GraphicsDevice, 1, 1);
				Color[] pixels = new Color[1];
				pixels[0] = new Color(0x63, 0x63, 0xFF);
				InteractionPixelBG.SetData<Color>(pixels);
			}

			switch (MenuState) {
				case MenuState.Animation:
					break;
				case MenuState.PressToStart:
					SpriteBatch.Begin();
					SpriteBatch.Draw(InteractionPixelBG, new Rectangle(0, 0, GameEngine.WIDTH, GameEngine.HEIGHT), Color.White);
					SpriteBatch.End();
					float opacity = !transitioning ? 1f : (1f - ((float) (Environment.TickCount - KeyDownSpan) / transitionTime));
					FontRenderer.Instance.DrawCentered(SpriteBatch, "Press any button to start", 2, GameEngine.HEIGHT - 30, opacity);
					break;
				case MenuState.Interaction:
					SpriteBatch.Begin();
					SpriteBatch.Draw(InteractionPixelBG, new Rectangle(0, 0, GameEngine.WIDTH, GameEngine.HEIGHT), Color.White);
					SpriteBatch.End();

					int x = 20;
					int y = 16;
					int i = 0;

					foreach (BoxInfo box in Boxes) {
						//time for maths
						int h = 2 + Regex.Matches(box.Message, "\n").Count * 2;
						if (h == 2) h++;

						if (i == Selection) {
							const float mod1 = 300f; //fade in/out duration
							const int mod2 = 600; //flashing period (must be mod1*2)
							const int mod3 = 400; //idle period

							float res = 1f;
							int opc = GameTime.TotalGameTime.Milliseconds % (mod2 + mod3);

							if (opc < mod1) res = opc / mod1;
							else if (opc < mod2) res = (1f - ((opc - mod1) / mod1));
							else res = 0f;

							//BoxUtil.Instance.DrawBox(SpriteBatch, 2, x, y, 27, h);
							//BoxUtil.Instance.DrawBox(SpriteBatch, 1, x, y, 27, h, res);
						} // else BoxUtil.Instance.DrawBox(SpriteBatch, 0, x, y, 27, h);
						string[] spl = box.Message.Split(new string[] {"\n"}, StringSplitOptions.None);
						foreach (string str in spl) {
							FontRenderer.Instance.Draw(SpriteBatch, str, 1, x + 6, y + 15);
							y += 13;
						}
						y += 14;
						i++;
					}

					break;
			}
		}

		public class BoxInfo {
			public string Message;
			public bool Fill;

			public BoxInfo(string message, bool fill) {
				this.Message = message;
				this.Fill = fill;
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Data;
using GameEngine.Data.GameLoader;
using GameEngine.Data.Input;
using GameEngine.Data.Scenes;
using GameEngine.Data.Text.Fonts;
using GameEngine.Data.Util;
using General.Common;
using General.Encoding;
using General.Encoding.BackwardCompatibility;
using General.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game = Microsoft.Xna.Framework.Game;

namespace GameEngine.Data {
	public class GameEngine : Game {
		public const Single SCALE = 2f;
		public const Int32 WIDTH = 256;
		public const Int32 HEIGHT = 192;

		//Remember to put this back to nothing later on
		//public string GameDumpLocation = @"C:\Users\Oxysoft\Desktop\Visual Studio 2012\Projects\PokeSharp\GameEngine\GameEngine\bin\Debug\Games\Sample1.psg";
		//public World GameDumpWorld = null;

		public bool Initialized { get; set; }
		public GraphicsDeviceManager GraphicsDeviceManager;
		public SpriteBatch SpriteBatch;
		public GameData Data;
		public IScene Scene;

		public GameScene GameScene {
			get { return Scene as GameScene; }
		}

		public MenuScene MenuScene {
			get { return Scene as MenuScene; }
		}

		public GameEngine() {
			this.GraphicsDeviceManager = new GraphicsDeviceManager(this);

			GraphicsDeviceManager.PreferredBackBufferWidth = (Int32) (WIDTH * SCALE);
			GraphicsDeviceManager.PreferredBackBufferHeight = (Int32) (HEIGHT * SCALE);

			this.IsMouseVisible = true;
			this.Window.Title = "PokeSharp Engine";
		}

		public void ChangeScene(IScene scene) {
			this.Scene = scene;
		}

		public bool GameSaveExists() {
			return false;
		}

		protected override void Initialize() {
			base.Initialize();

			this.SpriteBatch = new SpriteBatch(GraphicsDevice);

			DataLoader.Initialize();
			FontRenderer.Instance.Initialize(GraphicsDevice);

			Initialized = true;
			Dump();

			LoadWorld(@"C:\Users\Oxysoft\Desktop\Visual Studio 2012\Projects\PokeSharp\GameEngine\GameEngine\bin\Debug\Games\Sample1.psg");

			this.Scene = new MenuScene(this.Data, this.SpriteBatch);
		}

		public void ClearWorld() {
			this.Data = null;
			this.Scene = null;
		}

		public void LoadWorld(string location) {
			LoadWorld(null, location);
		}

		public void LoadWorld(World baseworld) {
			LoadWorld(baseworld, null);
		}

		public void LoadWorld(World GameDumpWorld, string GameDumpLocation) {
			if (GameDumpWorld == null && GameDumpLocation == null) return;
			if (GameDumpWorld != null) {
				Stream stream = new MemoryStream();
				GameData.DumpGame(GameDumpWorld, new BinaryOutput(stream));
				stream.Seek(0, SeekOrigin.Begin);
				this.Data = GameData.ReadGame(this.GraphicsDevice, new BinaryInput(stream));
				stream.Flush();
				stream.Close();
			} else {
				if (!string.IsNullOrEmpty(GameDumpLocation)) {
					this.Data = GameData.ReadGame(this.GraphicsDevice, GameDumpLocation);
				} else {
					using (OpenFileDialog dialog = new OpenFileDialog()) {
						dialog.Filter = "PokeSharp Game Dump (*.psg)|*.psg";
						if (dialog.ShowDialog() == DialogResult.OK) {
							this.Data = GameData.ReadGame(this.GraphicsDevice, GameDumpLocation);
						} else {
							Environment.Exit(0);
						}
					}
				}
			}
		}

		protected override void Update(GameTime gameTime) {
			base.Update(gameTime);
			InputHandler.Instance.Poll(gameTime);

			if (MenuScene != null && Scene.SceneState == Scenes.SceneState.Dead) {
				ChangeScene(new GameScene(Data, this.SpriteBatch));
			}

			if (Initialized && this.Scene != null) {
				Scene.Update(gameTime);
			}
		}

		protected override void Draw(GameTime gameTime) {
			try {
				//SETUP DRAWING
				RenderTarget2D target = new RenderTarget2D(GraphicsDevice, WIDTH, HEIGHT);
				GraphicsDevice.SetRenderTarget(target);
				GraphicsDevice.Clear(Color.BlanchedAlmond);

				if (Initialized && this.Scene != null) {
					//PERFORM GAME DRAWING
					base.Draw(gameTime);
					Scene.Draw(gameTime);
				}

				//FINALIZE DRAWING
				GraphicsDevice.SetRenderTarget(null);
				SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
				SpriteBatch.Draw(target, new Rectangle(0, 0, (int) (WIDTH * SCALE), (int) (HEIGHT * SCALE)), Color.White);
				SpriteBatch.End();
			} catch (InvalidOperationException exc) {
				Console.WriteLine("IOE EXC");
			}
		}

		public void Dump() {
			try {
				Texture2D texture = Texture2D.FromStream(this.GraphicsDevice, File.OpenRead(@"C:\Users\Oxysoft\Desktop\_splitter_tool\input.png"));
				string dumploc = @"C:\Users\Oxysoft\Desktop\_splitter_tool\newdump\";
				const int cols = 10;
				const int rows = 10;
				TileableTexture tileableTexture = new TileableTexture(texture, cols, rows);
				List<RenderTarget2D> results = new List<RenderTarget2D>();
				Color chroma1 = new Color(0xBF, 0xC8, 0xFF);
				Color chroma2 = new Color(0xD8, 0xDE, 0xFF);
				for (int y = 0; y < rows; y++) {
					for (int x = 0; x < cols; x++) {
						int[] order = new int[4 * 4];

						order[0] = 5;
						order[1] = 11;
						order[2] = 5;
						order[3] = 8;
						order[4] = 6;
						order[5] = 3;
						order[6] = 6;
						order[7] = 9;
						order[8] = 1;
						order[9] = 4;
						order[10] = 1;
						order[11] = 7;
						order[12] = 0;
						order[13] = 2;
						order[14] = 0;
						order[15] = 10;

						RenderTarget2D renderTarget = new RenderTarget2D(GraphicsDevice, 96, 128);
						TileableTexture tileableRenderTarget = new TileableTexture(renderTarget, 3, 4);
						GraphicsDevice.SetRenderTarget(renderTarget);
						SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
						spriteBatch.Begin();
						spriteBatch.Draw(texture, new Rectangle(0, 0, 96, 128), tileableTexture.GetSource(tileableTexture.GetIndex(x, y)), Color.White);
						spriteBatch.End();
						GraphicsDevice.SetRenderTarget(null);
						RenderTarget2D resultTarget = new RenderTarget2D(GraphicsDevice, 128, 128);
						TileableTexture tileableResultTarget = new TileableTexture(resultTarget, 4, 4);
						GraphicsDevice.SetRenderTarget(resultTarget);
						GraphicsDevice.Clear(Color.Transparent);

						spriteBatch.Begin();
						for (int i = 0; i < order.Length; i++) {
							Rectangle target = tileableResultTarget.GetSource(i);
							spriteBatch.Draw(renderTarget, target, tileableRenderTarget.GetSource(order[i]), Color.White);
						}
						spriteBatch.End();
						GraphicsDevice.SetRenderTarget(null);

						//----> Start of CHROMA CLEARING
						Color[] colors = new Color[resultTarget.Width * resultTarget.Height];
						resultTarget.GetData<Color>(colors);

						for (int i = 0; i < colors.Length; i++) {
							if (colors[i] == chroma1 || colors[i] == chroma2) colors[i] = Color.Transparent; 
						}

						resultTarget.SetData<Color>(colors);
						//End of CHROMA CLEARING <----
						
						results.Add(resultTarget);
					}
				}
				for (int i = 0; i < results.Count; i++) {
					results[i].SaveAsPng(File.OpenWrite(dumploc + i + ".png"), results[i].Width, results[i].Height);
				}
			} catch (Exception e) {
				Console.WriteLine("what da fack");
			}
		}

		public void SampleFontRenderer() {
			List<string> strings = new List<string>();
			strings.Add("0123456789");
			strings.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
			strings.Add("abcdefghijklmnopqrstuvwxyz");
			strings.Add("ÀÁÂÄÇÈÉÊËÌÍÎÏÑÒÓÔÖ×ÙÚÛÜß");
			strings.Add("àáâäǻçèéêëìíîïñòóôö÷ùúûüŒœᵃᵒᵉᶠʳ");
			strings.Add("₱¡¿!?,.…`/''“”„«»()♂♀+-*#=&~:;");

			const int font = 2;

			for (int i = 0; i < strings.Count; i++) {
				FontRenderer.Instance.Draw(SpriteBatch, strings[i], 0, 50, 98 + (i * 12));
			}

			for (int i = 0; i < strings.Count; i++) {
				FontRenderer.Instance.Draw(SpriteBatch, strings[i], 1, 50, 98 + (i * 12) + (strings.Count * 12) + 12);
			}

			for (int i = 0; i < strings.Count; i++) {
				FontRenderer.Instance.Draw(SpriteBatch, strings[i], font, 50, 12 + 12 + 98 + (i * 12) + (strings.Count * 12) * 2);
			}
		}
	}
}
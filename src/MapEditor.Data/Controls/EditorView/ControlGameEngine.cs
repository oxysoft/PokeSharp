using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Data;
using GameEngine.Data.GameLoader;
using GameEngine.Data.Input;
using GameEngine.Data.Scenes;
using General.Encoding;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlGameEngine : GameControl {
		public const Single SCALE = 2f;
		public const Int32 WIDTH = 256;
		public const Int32 HEIGHT = 192;

		public World World;

		public ControlGameEngine(World world) {
			this.World = world;
			this.GameLoopEnabled = true;
		}

		public SpriteBatch SpriteBatch;
		public bool Initialized = false;
		public GameData Data;
		public IScene Scene;

		public GameScene GameScene {
			get {
				return Scene as GameScene;
			}
		}

		public MenuScene MenuScene {
			get {
				return Scene as MenuScene;
			}
		}

		public void ChangeScene(IScene scene) {
			this.Scene = scene;
		}

		public void ClearWorld() {
			this.Data = null;
			this.Scene = null;
		}

		public void LoadWorld() {
			if (World != null) {
				Stream stream = new MemoryStream();
				GameData.DumpGame(World , new BinaryOutput(stream));
				stream.Seek(0, SeekOrigin.Begin);
				this.Data = GameData.ReadGame(this.GraphicsDevice, new BinaryInput(stream));
				stream.Flush();
				stream.Close();
			}

			this.Scene = new MenuScene(this.Data, this.SpriteBatch);
		}

		public override void LoadContent() {
			this.SpriteBatch = new SpriteBatch(GraphicsDevice);

			LoadWorld();

			this.Initialized = true;
			base.LoadContent();
		}

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			base.Update(gameTime);
			InputHandler.Instance.Poll(gameTime);

			if (MenuScene != null && Scene.SceneState == SceneState.Dead) {
				ChangeScene(new GameScene(Data, this.SpriteBatch));
			}

			if (Initialized && this.Scene != null) {
				Scene.Update(gameTime);
			}
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
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
				SpriteBatch.Draw(target, new Rectangle(0, 0, (int)(WIDTH * SCALE), (int)(HEIGHT * SCALE)), Color.White);
				SpriteBatch.End();
			} catch (InvalidOperationException exc) {
				Console.WriteLine("IOE EXC");
			}
		}
	}
}

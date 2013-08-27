using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets;
using Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokeSharp.Entity.Mob;
using PokeSharp.Maps;
using PokeSharp.Maps.Tiles;
using PokeSharp.PokeUtil;

namespace PokeSharp {

	class PokeEngine : Game {

		public const int SCALE = 2;
		public const int HEIGHT = 177;
		public const int WIDTH = 256;
		public static PokeEngine instance;

		public GraphicsDeviceManager graphics;
		public SpriteBatch sbatch;
		public Map map;
		private IntPtr drawSurface;

		public PokeEngine(IntPtr drawSurface) {
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferHeight = PokeEngine.HEIGHT * PokeEngine.SCALE;
			graphics.PreferredBackBufferWidth = PokeEngine.WIDTH * PokeEngine.SCALE;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			IsFixedTimeStep = false;
			if ((int)drawSurface != 0) {
				this.drawSurface = drawSurface;
				graphics.PreparingDeviceSettings +=
				new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
				System.Windows.Forms.Control.FromHandle((this.Window.Handle)).VisibleChanged +=
				new EventHandler(Game1_VisibleChanged);
			}
			instance = this;
		}

		void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e) {
			e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle =
			drawSurface;
		}

		private void Game1_VisibleChanged(object sender, EventArgs e) {
			if (System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible == true)
				System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible = false;
		}



		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
			base.LoadContent();
			sbatch = new SpriteBatch(GraphicsDevice);
			Art.loadAssets(GraphicsDevice);
			MapProvider.getInstance().loadConnections();
			map = MapProvider.getInstance().getMap(0);
			//new Map(this, 0);
			Font.initialize(GraphicsDevice);
		}

		protected override void UnloadContent() {
			base.UnloadContent();
		}

		int totalframes = 0;
		float elapsedtime = 0.0f;
		int fps = 0;

		protected override void Update(GameTime gameTime) {
			elapsedtime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			//bitwise (x << y OR x >> y) 9438 milliseconds
			//decimal (x * y OR x / y) 20561 milliseconds

			//benchmark!!!
			/*
			for (int i = 0; i < 2100000000; i++) {
				long u = i >> 4;
				u = i << 2;
				u = i >> 3;
				u = i << 8;
				
				long u = i / 16;
				u = i * 4;
				u = i / 8;
				u = i * 256;
			}
			*/

			for (int i = 0; i < 1; i++) {
				if (elapsedtime > 1000.0f) {
					fps = totalframes;
					totalframes = 0;
					elapsedtime = 0;
				}
				InputHandler.pollKeys();
				map.update();
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			totalframes++;
			//long before = Environment.TickCount;
			BatchUtil.BeginNoAA(sbatch, this);
			GraphicsDevice.Clear(Color.Black);
			map.render();
			Font.Draw(sbatch, "x. " + ((int)map.player.x >> 4) + ", y. " + ((int)map.player.y >> 4), 16, 16, 2);
			Font.Draw(sbatch, "Map id: " + map.mapid, 16, 25, 2);
			Font.Draw(sbatch, "fps: " + fps, 16, 34, 2);
			sbatch.End();
			//long diff = Environment.TickCount - before;
			//Console.WriteLine("Diff : " + diff);
			base.Draw(gameTime);
		}

		public void changeMap(Map map) {
			this.map = map;
		}

		[STAThread]
		public static void Main(String[] args) {
			/*using (Form1 form = new Form1()) {
				form.Show();
				using (PokeEngine game = new PokeEngine(form.getDrawSurface())) {
					game.Run();
				}
			}*/
			using (PokeEngine engine = new PokeEngine((IntPtr)0)) {
				engine.Run();
			}
		}

		public static int[] generateSpindaSpots(uint pid) {
			int[] result = new int[1 << 3];

			int a = (int) ((pid >> 24) & 0xff);
			int r = (int) ((pid >> 16) & 0xff);
			int g = (int) ((pid >> 8) & 0xff);
			int b = (int) ((pid & 0xff));

			result[0] = a & 0xf0;
			result[1] = a & 0x0f;
			result[2] = r & 0xf0;
			result[3] = r & 0x0f;
			result[4] = g & 0xf0;
			result[5] = g & 0x0f;
			result[6] = b & 0xf0;
			result[7] = b & 0x0f;

			return result;
		}

	}
}

using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	using Color = System.Drawing.Color;

	public class GameControl : Control {
		#region Constructors

		public GameControl() {
			this.services = new ServiceContainer();

			this.content = new ContentManager(this.services);
			this.content.RootDirectory = ".";

			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
			this.SetStyle(ControlStyles.UserPaint, true);

			this.GameLoopEnabled = true;
			this.TimeStep = 16.66666f;

			this.startTime = DateTime.Now;
		}

		#endregion

		#region Fields

		private ServiceContainer services;
		private GraphicsDeviceService service;
		private ContentManager content;

		private DateTime startTime;

		private DateTime lastDraw;
		private DateTime lastUpdate;

		private Thread gameLoopThread;
		private Thread eventThread;

		private string errorMessage;

		#endregion

		#region Properties

		public bool GameLoopEnabled { get; set; }
		public float TimeStep { get; set; }

		public GraphicsDevice GraphicsDevice {
			get {
				if (!this.DesignMode) {
					return this.service.GraphicsDevice;
				}
				return null;
			}
		}

		public ContentManager Content {
			get { return this.content; }
		}

		public ServiceContainer Services {
			get { return services; }
		}

		#endregion

		#region Virtual Methods

		public virtual void Initialize() {
		}

		public virtual void LoadContent() {
		}

		public virtual void UnloadContent() {
		}

		public virtual void Draw(GameTime gameTime) {
		}

		public virtual void Update(GameTime gameTime) {
		}

		#endregion

		#region Methods

		public void BeginDraw() {
			if (this.service == null) {
				this.errorMessage = Messages.LostDevice;
			}
			this.handleDeviceReset();

			if (string.IsNullOrEmpty(this.errorMessage)) {
				this.setupViewport();
			}
		}

		public void EndDraw() {
			try {
				this.GraphicsDevice.Present(new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height),	null, this.Handle);
			} catch (DeviceLostException) {
				this.handleDeviceReset();
			} catch (OutOfMemoryException exc) {
				Console.WriteLine("GraphicsDevice.Present oom");
			}
		}

		public void Reset() {
			try {
				this.service.ResetDevice(ClientSize.Width, ClientSize.Height);
			} catch {
				this.errorMessage = Messages.ResetFailed;
			}
		}

		private void setupViewport() {
			if (this.ClientSize.Width > 0 && this.ClientSize.Height > 0) {
				this.GraphicsDevice.Viewport = new Viewport() {
					                                              X = 0, Y = 0,
					                                              Width = ClientSize.Width,
					                                              Height = ClientSize.Height,
					                                              MinDepth = 0, MaxDepth = 1
				                                              };
			}
		}

		private void handleDeviceReset() {
			bool needsReset = false;
			switch (GraphicsDevice.GraphicsDeviceStatus) {
				case GraphicsDeviceStatus.Lost:
					this.errorMessage = Messages.LostDevice;
					break;

				case GraphicsDeviceStatus.NotReset:
					needsReset = true;
					break;

				default:
					PresentationParameters pp = GraphicsDevice.PresentationParameters;
					needsReset = (ClientSize.Width > pp.BackBufferWidth) || (ClientSize.Height > pp.BackBufferHeight);
					break;
			}
			if (needsReset) {
				this.Reset();
			}
		}

		/*private void paintDefault(Graphics graphics, string text) {
			//graphics.Clear(Color.DodgerBlue);

			using (Brush brush = new SolidBrush(Color.Black)) {
				using (StringFormat format = new StringFormat()) {
					format.Alignment = StringAlignment.Center;
					format.LineAlignment = StringAlignment.Center;

					//graphics.DrawString(text, Font, brush, this.ClientRectangle, format);
				}
			}
		}*/

		private void gameLoop() {
			Action loadContent = this.LoadContent;
			Action unloadContent = this.UnloadContent;

			this.lastUpdate = DateTime.Now;
			this.lastDraw = DateTime.Now;

			this.Invoke(loadContent);
			while (!this.IsDisposed) {
				try {
					DateTime drawStart = DateTime.Now;

					Action performDraw = () => {
						this.BeginDraw();
						GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.FromNonPremultiplied(0x31, 0x31, 0x31, 0xff));
						this.Draw(new GameTime(drawStart - this.startTime, drawStart - this.lastDraw));
						this.EndDraw();
					};
					this.Invoke(performDraw);
					this.lastDraw = drawStart;

					DateTime updateStart = DateTime.Now;

					Action performUpdate = () => { this.Update(new GameTime(updateStart - this.startTime, updateStart - this.lastUpdate)); };
					this.Invoke(performUpdate);
					this.lastUpdate = updateStart;

					TimeSpan elapsed = DateTime.Now - drawStart;
					if (elapsed.TotalMilliseconds >= this.TimeStep) continue;

					Thread.Sleep(TimeSpan.FromMilliseconds(this.TimeStep) - elapsed);
				} catch {
				}
			}
			this.Invoke(unloadContent);
		}

		#endregion

		#region Control Member

		protected override void OnCreateControl() {
			if (!this.DesignMode) {
				this.service = GraphicsDeviceService.AddReference(
					Handle,
					ClientSize.Width,
					ClientSize.Height);

				this.service.DeviceReset += new EventHandler<EventArgs>(onDeviceReset);
				this.services.AddService<IGraphicsDeviceService>(service);

				if (this.GameLoopEnabled) {
					this.gameLoopThread = new Thread(this.gameLoop);
					this.gameLoopThread.IsBackground = true;
					this.gameLoopThread.Priority = ThreadPriority.Normal;

					this.gameLoopThread.Start();
				} else {
					this.LoadContent();
				}
			}
			base.OnCreateControl();
		}

		protected override void Dispose(bool disposing) {
			if (this.service != null) {
				this.service.Release(disposing);
				this.service = null;

				if (this.gameLoopThread != null && this.gameLoopThread.IsAlive) {
					this.gameLoopThread.Abort();
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
			if (this.DesignMode) {
				e.Graphics.Clear(Color.FromArgb(0x15, 0x15, 0x15));
			} else {
				if (!this.GameLoopEnabled && this.GraphicsDevice != null) {
					GameTime gameTime = new GameTime(TimeSpan.Zero, TimeSpan.Zero);

					this.BeginDraw();
					{
						this.Draw(gameTime);
					}
					this.EndDraw();
				}
			}
		}

		#endregion

		#region Event Handlers

		private void onDeviceReset(object sender, EventArgs e) {
			this.Initialize();
			this.errorMessage = string.Empty;
		}

		#endregion

		#region Classes

		public static class Messages {
			public static string DesignMode = "DESIGN MODE";
			public static string LostDevice = "LOST DEVICE";
			public static string ResetFailed = "RESET FAILED";
		}

		#endregion
	}
}
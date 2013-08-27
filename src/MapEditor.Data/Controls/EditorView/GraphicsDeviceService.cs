using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	internal class GraphicsDeviceService : IGraphicsDeviceService {
		#region Constructors
		private GraphicsDeviceService(IntPtr windowHandle, int width, int height) {
			this.parameters = new PresentationParameters();

			this.parameters.BackBufferWidth = Math.Max(width, 1);
			this.parameters.BackBufferHeight = Math.Max(height, 1);
			this.parameters.BackBufferFormat = SurfaceFormat.Color;
			this.parameters.DepthStencilFormat = DepthFormat.Depth24;
			this.parameters.DeviceWindowHandle = windowHandle;
			this.parameters.PresentationInterval = PresentInterval.Immediate;
			this.parameters.IsFullScreen = false;

			this.graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, parameters);
		}
		#endregion

		#region Fields
		private static GraphicsDeviceService instance;
		private static int referenceCount;

		private GraphicsDevice graphicsDevice;
		private PresentationParameters parameters;
		#endregion

		#region Properties
		public GraphicsDevice GraphicsDevice {
			get {
				return graphicsDevice;
			}
		}
		#endregion

		#region Events
		public event EventHandler<EventArgs> DeviceCreated;
		public event EventHandler<EventArgs> DeviceDisposing;
		public event EventHandler<EventArgs> DeviceReset;
		public event EventHandler<EventArgs> DeviceResetting;
		#endregion

		#region Methods
		public void Release(bool disposing) {
			if (Interlocked.Decrement(ref referenceCount) == 0) {
				if (disposing) {
					if (DeviceDisposing != null) {
						DeviceDisposing(this, EventArgs.Empty);
					}
					graphicsDevice.Dispose();
				}
				graphicsDevice = null;
			}
		}
		public void ResetDevice(int width, int height) {
			if (DeviceResetting != null) {
				DeviceResetting(this, EventArgs.Empty);
			}

			this.parameters.BackBufferWidth = Math.Max(parameters.BackBufferWidth, width);
			this.parameters.BackBufferHeight = Math.Max(parameters.BackBufferHeight, height);
			this.graphicsDevice.Reset(parameters);

			if (DeviceReset != null) {
				DeviceReset(this, EventArgs.Empty);
			}
		}
		#endregion

		#region Static Methods
		public static GraphicsDeviceService AddReference(IntPtr windowHandle, int width, int height) {
			if (Interlocked.Increment(ref referenceCount) == 1) {
				instance = new GraphicsDeviceService(windowHandle, width, height);
			}
			return instance;
		}
		#endregion
	}
}
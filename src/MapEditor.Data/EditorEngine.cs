using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Editor.Selections;
using GameEngine.Data.Common;
using GameEngine.Data.Data;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Text.Fonts;
using GameEngine.Data.Tiles;
using General.Common;
using General.Encoding;
using General.Extensions;
using General.States;
using MapEditor.Data.Actions;
using MapEditor.Data.Controls.EditorView;
using MapEditor.Data.Interface;
using MapEditor.Data.Interface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MapEditor.Data {
	public class EditorEngine {
		public ScreenInterface ScreenInterface;
		public Dictionary<string, ActionManager> ActionManagers;
		public bool HasEdit { get; set; } //Is the last save not up to date?

		public Map CurrentMap {
			get {
				if (World == null) return null;
				return World.CurrentMap;
			}
			set {
				if (World != null) {
					World.CurrentMap = value;
					if (CurrentMap != null) {
						//center map on screen
						//int fx = Control.Width / 2 - (CurrentMap.Width << 3);
						//int fy = Control.Height / 2 - (CurrentMap.Height << 3);
						//xCam = -fx;
						//yCam = -fy;
						World.Camera.Location = Vector2.Zero;
					}
				}
			}
		}

		public int xCam {
			get { return (int) World.Camera.Location.X; }
			set { World.Camera.Location += new Vector2(value, 0); }
		}

		public int yCam {
			get { return (int) World.Camera.Location.Y; }
			set { World.Camera.Location += new Vector2(0, value); }
		}

		/*public int xCam {
			get { return World.xScroll; }
			set { World.xScroll = value; }
		}

		public int yCam {
			get { return World.yScroll; }
			set { World.yScroll = value; }
		}*/

		public int xCamZ {
			get { return (int) (xCam * World.Camera.Scale); }
		}

		public int yCamZ {
			get { return (int) (yCam * World.Camera.Scale); }
		}

		public World World;
		public GraphicsDevice GraphicsDevice;
		public ControlEditorView Control;
		public FiniteStateMachine StateMachine;
		public IServiceProvider Services;
		public bool Initialized;
		public int SelectedLayer = 0;

		public static EditorEngine Instance {
			get { return Static<EditorEngine>.Value; }
		}

		public void Initialize(ControlEditorView control, GraphicsDevice graphicsdevice, IServiceProvider services) {
			this.Control = control;
			this.GraphicsDevice = graphicsdevice;
			this.Services = services;
			this.StateMachine = new FiniteStateMachine();

			this.ActionManagers = new Dictionary<string, ActionManager>();

			this.ScreenInterface = new EditorInterface(control);

			//DataLoader.Initialize();
			FontRenderer.Instance.Initialize(GraphicsDevice);
		}

		public ActionManager GetActionManager() {
			return GetActionManager(CurrentMap);
		}

		public ActionManager GetActionManager(Map map) {
			if (map != null) {
				if (ActionManagers.ContainsKey(map.Name)) {
					return ActionManagers[map.Name];
				} else {
					ActionManager result = new ActionManager();
					ActionManagers.Add(map.Name, result);
					return result;
				}
			}
			return null;
		}

		public Texture2D LoadTexture(string loc) {
			using (FileStream stream = new FileStream(loc, FileMode.Open)) {
				return Texture2D.FromStream(GraphicsDevice, stream);
			}
		}

		public void loadTilesheetContainer(string tilesetContainer) {
			World.TilesetContainer = EncoderUtil.Decode<TilesetContainer>(tilesetContainer, GraphicsDevice);
		}

		public void loadObjectContainer(string objectContainer) {
			World.EntityContainer = EncoderUtil.Decode<EntityContainer>(objectContainer, GraphicsDevice);
		}

		public void addTileset(Tileset tilesheet) {
			World.TilesetContainer.Add(tilesheet);
		}

		public void addObject(EntityTemplate template) {
			World.EntityContainer.Add(template);
		}

		public int GetTilesetIndexByName(string name) {
			return World.TilesetContainer.IndexOf(this.GetTilesetByName(name));
		}

		public Tileset GetTilesetByName(string name) {
			Tileset result = null;
			foreach (Tileset sheet in World.TilesetContainer) {
				if (name.Equals(sheet.Name)) result = sheet;
			}
			return result;
		}

		public EntityTemplate GetModelByName(string name) {
			return World.EntityContainer.All().FirstOrDefault(model => model.Name == name);
		}

		public void RemoveTilesetByName(string name) {
			World.TilesetContainer.Remove(this.GetTilesetByName(name));
		}

		public void RemoveModelByName(string name) {
			World.EntityContainer.Remove(this.GetModelByName(name));
		}

		public World CreateRegion(string name) {
			Initialized = true;
			World = new World(name, GraphicsDevice);
			World.Maps.Clear();
			return World;
		}

		public Map CreateMap(string name, int w, int h, List<string> sheets) {
			Map result = new Map(World.EntityFactory, name, World.Author, w, h);
			CurrentMap = result;
			World.Maps.Add(result);

			foreach (string arg in sheets) {
				int tilesetIndex = GetTilesetIndexByName(arg);
				MockupTileset reference = new MockupTileset(World, tilesetIndex);

				CurrentMap.Tilesets.Add(reference);
			}

			ScreenInterface.Initialize();

			return result;
		}

		public void SwapMap(int index) {
			if (index > -1 && index < World.Maps.Count) {
				Map result = World.Maps[index];
				SwapMap(result);
			}
		}

		public void SwapMap(Map map) {
			this.CurrentMap = map;
		}

		public void SavePictureOfMap(string loc) {
			GraphicsDevice graphicsdevice = World.ViewData.GraphicsDevice;
			RenderTarget2D target = new RenderTarget2D(graphicsdevice, CurrentMap.Width << 4, CurrentMap.Height << 4);
			graphicsdevice.SetRenderTarget(target);

			Vector2 cScrolling = World.Camera.Location;
			float cScale = World.Camera.Scale;
			float cRotation = World.Camera.Rotation;

			World.Camera.Reset();

			RenderMap(CurrentMap);

			World.Camera.Location = cScrolling;
			World.Camera.Scale = cScale;
			World.Camera.Rotation = cRotation;

			graphicsdevice.SetRenderTarget(null);
			using (FileStream fs = File.OpenWrite(loc)) {
				target.SaveAsPng(fs, target.Width, target.Height);
			}
		}

		public void RenderMap(Map map) {
			List<MapEntity> entitiesToRender = new List<MapEntity>();

			GameTime time = new GameTime();
			map.Draw(time);

			foreach (MapEntity entity in map.Entities) {
				entitiesToRender.Add(entity);
			}

			entitiesToRender.Sort(delegate(MapEntity a, MapEntity b) {
				float positionA = a.Position.Y + a.Template.Texture.FrameHeight;
				float positionB = b.Position.Y + b.Template.Texture.FrameHeight;

				if (a.TopMost && !b.TopMost) return 1;
				if (!a.TopMost && b.TopMost) return -1;

				if (positionA > positionB) return 1;
				if (positionA < positionB) return -1;

				if (positionA == positionB) {
					if (a.Position.X > b.Position.X) return -1;
					if (a.Position.X < b.Position.X) return 1;
				}

				return 0;
			});

			foreach (MapEntity entity in entitiesToRender) {
				entity.BeginDraw(time);
				entity.Draw(time);
				entity.EndDraw(time);
			}
		}

		public void Update(Microsoft.Xna.Framework.GameTime time) {
			if (Initialized && World != null) {
				World.Update(time);
				StateMachine.Update(time);
			}
		}

		public void Draw(Microsoft.Xna.Framework.GameTime time) {
			if (!Initialized || World == null) return;
			if (CurrentMap == null) return;
			int w = CurrentMap.Width << 4;
			int h = CurrentMap.Height << 4;

			GraphicsDevice.Clear(new Color(0x2f, 0x2f, 0x2f));
			SpriteBatch batch = World.ViewData.SpriteBatch;
			batch.Begin(Matrix.CreateScale(1));

			SelectionUtil.FillRectangle(World.ViewData.SpriteBatch, Color.White * 0.5f, new Rectangle((int) World.Camera.Location.X, (int) World.Camera.Location.Y, (int) (w * World.Camera.Scale), (int) (h * World.Camera.Scale)));

			CurrentMap.Draw(time);

			if (this.World.Camera.Scale <= 0) {
				this.World.Camera.Scale = 1f;
			}

			StateMachine.Draw(time);

			if (Options.Instance.Grid) {
				if (CurrentMap != null) {
					//We could draw a rectangle for every Tiles...
					//Or we could be smart and draw lines for columns and rows!

					Color c1 = Color.DeepSkyBlue;
					Color c2 = Color.Black;

					float trans_white = Options.Instance.GridOpacity;
					float trans_black = Options.Instance.GridOpacity;

					//rows
					for (int y = 0; y < CurrentMap.Height; y++) {
						SelectionUtil.DrawStraightLine(World.ViewData.SpriteBatch, c1, trans_white, 0, (y << 4), CurrentMap.Width * 16, 1);
						SelectionUtil.DrawStraightLine(World.ViewData.SpriteBatch, c2, trans_black, 0, (y << 4) + 1, CurrentMap.Width * 16, 1);
					}

					//columns
					for (int x = 0; x < CurrentMap.Width; x++) {
						SelectionUtil.DrawStraightLine(World.ViewData.SpriteBatch, c1, trans_white, x << 4, 0, 1, CurrentMap.Height << 4);
						SelectionUtil.DrawStraightLine(World.ViewData.SpriteBatch, c2, trans_black, (x << 4) + 1, 0, 1, CurrentMap.Height << 4);
					}
				}
			}

			ScreenInterface.Draw(time);
			//batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
			//batch.Draw(renderTarget, new Rectangle(xCam, yCam, (int) (renderTarget.Width * Zoom), (int) (renderTarget.Height * Zoom)), Color.White);
			batch.End();
		}

		public void ZoomIn(float delta) {
			if (World.Camera.Scale + delta < 10f) World.Camera.Scale += delta;
		}

		public void ZoomOut(float delta) {
			if (World.Camera.Scale - delta > 0f) World.Camera.Scale -= delta;
		}

		public void ZoomIn() {
			ZoomIn(.5f);
		}

		public void ZoomOut() {
			ZoomOut(.5f);
		}

		public void CenterView() {
			xCam = (int) (Control.Width / 2 - (CurrentMap.Width << 4) / 2);
			yCam = (int) (Control.Height / 2 - (CurrentMap.Height << 4) / 2);
		}

		public void MoveView(int xchange, int ychange) {
			/*if (Zoom != 0) {
				xchange = (int) (xchange / Zoom);
				ychange = (int) (ychange / Zoom);
			}*/

			World.Camera.Location += new Vector2(xchange, ychange);

			ScreenInterface.xCam = xCam;
			ScreenInterface.yCam = yCam;
		}

		public void MouseEnter(EventArgs e) {
		}

		public void MouseLeave(EventArgs e) {
		}
	}
}
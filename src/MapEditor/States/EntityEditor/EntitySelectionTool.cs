using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Entities;
using General.Common;
using General.Extensions;
using General.States;
using MapEditor.Data;
using MapEditor.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MapEditor.States.EntityEditor {
	public class EntitySelectionTool : State, IState {
		public EntitySelectionTool() {
			this.selection = new Selection();
			selection.anti_negative = false;
			this.selection.GridWidth = 1;
			this.selection.GridHeight = 1;

			this.SelectedEntities = new List<MapEntity>();
			this.EntitiesToSelect = new List<MapEntity>();
		}

		public static EntitySelectionTool Instance {
			get { return Static<EntitySelectionTool>.Value; }
		}

		private Selection selection;
		private Rectangle selectedRegion;

		public bool CtrlDown {
			get { return Keyboard.GetState().IsKeyDown(Keys.LeftControl); }
		}

		public bool ShiftDown {
			get { return Keyboard.GetState().IsKeyDown(Keys.LeftShift); }
		}

		public List<MapEntity> SelectedEntities { get; private set; }
		public List<MapEntity> EntitiesToSelect { get; private set; }

		private void drawOverlay(MapEntity worldEntity, GameTime gameTime) {
			SpriteBatch spriteBatch = EditorEngine.Instance.World.ViewData.SpriteBatch;
			float opacity = worldEntity.Opacity;
			bool shadow = worldEntity.Shadow;

			worldEntity.Opacity = 0.5f;
			worldEntity.Shadow = false;
			worldEntity.blendstate = BlendState.Additive;

			spriteBatch.End();

			worldEntity.BeginDraw(gameTime);
			worldEntity.Draw(gameTime);
			worldEntity.EndDraw(gameTime);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);

			worldEntity.Opacity = opacity;
			worldEntity.Shadow = shadow;
			worldEntity.blendstate = BlendState.NonPremultiplied;
		}

		public string Name {
			get { return "Selection"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EditorForm.b_entityselect.Checked = true;

			this.EditorForm.editorcontrol.MouseDown += onMouseDown;
			this.EditorForm.editorcontrol.MouseDown += onMouseChange;
			this.EditorForm.editorcontrol.MouseMove += onMouseChange;
			this.EditorForm.editorcontrol.MouseUp += onMouseUp;

			this.SelectedEntities.Clear();
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.b_entityselect.Checked = false;

			this.EditorForm.editorcontrol.MouseDown -= onMouseDown;
			this.EditorForm.editorcontrol.MouseDown -= onMouseChange;
			this.EditorForm.editorcontrol.MouseMove -= onMouseChange;
			this.EditorForm.editorcontrol.MouseUp -= onMouseUp;
		}

		public void Draw(GameTime gameTime) {
			SpriteBatch spriteBatch = EditorEngine.Instance.World.ViewData.SpriteBatch;

			foreach (MapEntity worldEntity in SelectedEntities) {
				this.drawOverlay(worldEntity, gameTime);
			}
			foreach (MapEntity worldEntity in EntitiesToSelect) {
				this.drawOverlay(worldEntity, gameTime);
			}

			if (this.selectedRegion != Rectangle.Empty) {
				float scale = EditorEngine.Instance.World.Camera.Scale;
				Vector2 scroll = EditorEngine.Instance.World.Camera.Location;

				Rectangle displayRegion = new Rectangle((int) (this.selectedRegion.X * scale), (int) (this.selectedRegion.Y * scale), (int) (selectedRegion.Width * scale), (int) (selectedRegion.Height * scale)).Add(scroll);

				SelectionUtil.DrawRectangle(
					spriteBatch,
					Color.Black,
					new Rectangle(
						displayRegion.X + 1,
						displayRegion.Y + 1,
						displayRegion.Width,
						displayRegion.Height));

				SelectionUtil.DrawRectangle(spriteBatch, Color.White, displayRegion);
			}
		}

		public void Update(GameTime gameTime) {
		}

		private void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (!Keyboard.GetState().IsKeyDown(Keys.LeftControl) && !Keyboard.GetState().IsKeyDown(Keys.LeftShift))
					SelectedEntities.Clear();

				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				selection.Start(new Vector2(xt, yt));
			}
		}

		private void onMouseChange(object sender, MouseEventArgs e) {
			this.EditorForm.Focus();
			if (e.Button == MouseButtons.Left) {
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				this.selection.End(new Vector2(xt, yt));
				this.selectedRegion = this.selection.Region;

				IEnumerable<Entity> enumeration = EditorEngine.Instance.CurrentMap.Entities;

				foreach (MapEntity worldEntity in enumeration) {
					if (selectedRegion.Intersects(worldEntity.Bounds)) {
						if (!EntitiesToSelect.Contains(worldEntity)) {
							EntitiesToSelect.Add(worldEntity);
						}
					} else {
						EntitiesToSelect.Remove(worldEntity);
					}
				}
			}
		}

		private void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				this.selection.Region = Rectangle.Empty;
				this.selectedRegion = this.selection.Region;

				foreach (MapEntity entity in EntitiesToSelect) {
					if (!SelectedEntities.Contains<MapEntity>(entity)) {
						if (!ShiftDown)
							SelectedEntities.Add(entity);
					}
					if (ShiftDown)
						SelectedEntities.Remove(entity);
				}

				EntitiesToSelect.Clear();
			}
		}
	}
}
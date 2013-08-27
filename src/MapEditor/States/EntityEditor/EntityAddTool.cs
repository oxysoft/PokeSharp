using System;
using System.Windows.Forms;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions.Object;
using MapEditor.Forms;
using Microsoft.Xna.Framework;

namespace MapEditor.States.EntityEditor {
	public class EntityAddTool : State, IState {
		private bool entered = true;

		public static EntityAddTool Instance {
			get { return Static<EntityAddTool>.Value; }
		}

		public string Name {
			get { return "Add Entity"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EditorForm.b_entityadd.Checked = true;

			this.EditorForm.editorcontrol.MouseDown += new MouseEventHandler(onMouseDown);
			this.EditorForm.editorcontrol.MouseMove += new MouseEventHandler(onMouseMove);
			this.EditorForm.editorcontrol.MouseLeave += new EventHandler(onMouseLeave);
			this.EditorForm.editorcontrol.MouseEnter += new EventHandler(onMouseEnter);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.b_entityadd.Checked = false;

			this.EditorForm.editorcontrol.MouseDown -= onMouseDown;
			this.EditorForm.editorcontrol.MouseMove -= onMouseMove;
			this.EditorForm.editorcontrol.MouseLeave -= onMouseLeave;
			this.EditorForm.editorcontrol.MouseEnter -= onMouseEnter;
		}

		public void Update(GameTime gameTime) {
		}

		public void Draw(GameTime gameTime) {
			EntityTemplate model = FrmEntitySelector.Instance.selectedEntity;
			if (model != null && entered) {
				MapEntity entity = model.CreateEntity(EditorEngine.Instance.World.EntityFactory, true);

				entity.Opacity = .5f;
				entity.Color = Color.LightGray;
				entity.Position = new Vector2(xt * 16, yt * 16);
				entity.Shadow = false;

				entity.Draw(gameTime);
			}
		}

		private int xt, yt;

		private void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				EntityTemplate model = FrmEntitySelector.Instance.selectedEntity;

				if (model != null) {
					AddEntityAction action = new AddEntityAction(
						model, new Vector2(xt, yt));

					EditorEngine.Instance.GetActionManager().Execute(action);
				}
			}
		}

		private void onMouseMove(object sender, MouseEventArgs e) {
			xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
			yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);
		}

		private void onMouseEnter(object sender, EventArgs e) {
			this.entered = true;
		}

		private void onMouseLeave(object sender, EventArgs e) {
			this.entered = false;
		}
	}
}
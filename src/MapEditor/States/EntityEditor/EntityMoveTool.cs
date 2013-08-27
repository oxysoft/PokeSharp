using System.Windows.Forms;
using GameEngine.Data.Entities;
using General.Common;
using General.States;
using Microsoft.Xna.Framework;

namespace MapEditor.States.EntityEditor {
	public class EntityMoveTool : State, IState {

		public static EntityMoveTool Instance {
			get {
				return Static<EntityMoveTool>.Value;
			}
		}

		public string Name {
			get {
				return "TryMove";
			}
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EditorForm.b_entitymove.Checked = true;

			this.EditorForm.editorcontrol.MouseDown += new MouseEventHandler(onMouseDown);
			this.EditorForm.editorcontrol.MouseMove += new MouseEventHandler(onMouseMove);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.b_entitymove.Checked = false;

			this.EditorForm.editorcontrol.MouseDown -= onMouseDown;
			this.EditorForm.editorcontrol.MouseMove -= onMouseMove;
		}

		public void Draw(GameTime gameTime) {
			EntitySelectionTool.Instance.Draw(gameTime);
		}

		public void Update(GameTime gameTime) {
		}

		private void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				lxt = e.X >> 4;
				lyt = e.Y >> 4;
			}
		}

		int lxt, lyt;

		private void onMouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int x = e.X >> 4;
				int y = e.Y >> 4;

				int xdif = lxt - x;
				int ydif = lyt - y;

				foreach (MapEntity worldEntity in EntitySelectionTool.Instance.SelectedEntities) {
					worldEntity.Position += new Vector2(-(xdif * 16), -(ydif * 16));
				}

				lxt = x;
				lyt = y;
			}
		}
	}
}

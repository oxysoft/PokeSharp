using System.Windows.Forms;
using General.Common;
using General.States;
using MapEditor.Data;

namespace MapEditor.States.General {
	public class MoveTool : State, IState {

		public string Name {
			get {
				return "TryMove Tool";
			}
		}

		public static MoveTool Instance {
			get {
				return Static<MoveTool>.Value;
			}
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EditorForm.b_hand.Checked = true;

			EditorForm.editorcontrol.MouseDown += new MouseEventHandler(onMouseDown);
			EditorForm.editorcontrol.MouseMove += new MouseEventHandler(onMouseMove);
			EditorForm.editorcontrol.MouseUp += new MouseEventHandler(onMouseUp);
		}
		
		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.b_hand.Checked = false;

			EditorForm.editorcontrol.MouseDown -= new MouseEventHandler(onMouseDown);
			EditorForm.editorcontrol.MouseMove -= new MouseEventHandler(onMouseMove);
			EditorForm.editorcontrol.MouseUp -= new MouseEventHandler(onMouseUp);
		}

		void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				lockControl = true;
				lmx = e.X;
				lmy = e.Y;
			}
		}

		bool lockControl;
		int lmx, lmy;

		void onMouseMove(object sender, MouseEventArgs e) {
			if (lockControl) {
				//move logic
				int cmx = e.X;
				int cmy = e.Y;

				int xdelta = (int) (-(lmx - cmx) / EditorEngine.Instance.World.Camera.Scale);
				int ydelta = (int) (-(lmy - cmy) / EditorEngine.Instance.World.Camera.Scale);

				EditorEngine.Instance.MoveView(xdelta, ydelta);

				lmx = cmx;
				lmy = cmy;
			}
		}

		void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				lockControl = false;
			}
		}

		public void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
		}

		public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
		}
	}
}

using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.States;
using MapEditor.Data;
using Microsoft.Xna.Framework;

namespace MapEditor.States.BehaviorEditor {
	public class TileBehaviorTool : State, IState {
		public static TileBehaviorTool Instance {
			get { return Static<TileBehaviorTool>.Value; }
		}

		public string Name {
			get { return "Tile behavior set tool"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.EditorForm.editorcontrol.MouseDown += onMouseMove;
			this.EditorForm.editorcontrol.MouseMove += onMouseMove;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.editorcontrol.MouseDown -= onMouseMove;
			EditorForm.editorcontrol.MouseMove -= onMouseMove;
		}

		private void onMouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				Map map = EditorEngine.Instance.CurrentMap;
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				MockupTileBehavior _ref = map.GetBehavior(xt, yt);

				if (xt < 0 || yt < 0 || xt >= map.Width || yt >= map.Height) return;
				if (_ref == null) return;

				_ref.BehaviorId = BehaviorEditorState.Instance.SelectedTileBehaviorId;
			}
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}
	}
}
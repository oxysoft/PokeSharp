using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions;
using MapEditor.Data.Actions.Tile;
using Microsoft.Xna.Framework;

namespace MapEditor.States.TileEditor {
	public class EraserTool : State, IState {
		private MultiAction action;

		public static EraserTool Instance {
			get { return Static<EraserTool>.Value; }
		}

		public string Name {
			get { return "Eraser"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.EditorForm.b_eraser.Checked = true;

			this.EditorForm.editorcontrol.MouseDown += new MouseEventHandler(onMouseMove);
			this.EditorForm.editorcontrol.MouseMove += new MouseEventHandler(onMouseMove);
			this.EditorForm.editorcontrol.MouseUp += new MouseEventHandler(onMouseUp);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			this.EditorForm.b_eraser.Checked = false;

			this.EditorForm.editorcontrol.MouseDown -= onMouseMove;
			this.EditorForm.editorcontrol.MouseMove -= onMouseMove;
			this.EditorForm.editorcontrol.MouseUp -= onMouseUp;
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}

		private int lxt = -1;
		private int lyt = -1;

		private void onMouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (this.action == null) {
					this.action = new MultiAction("Eraser");
				}

				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);

				if (xt != lxt || yt != lyt) {
					int tilesetIndex = TileEditorState.Instance.SelectedTileset;

					MockupTile t = EditorEngine.Instance.CurrentMap.GetTile(xt, yt, EditorEngine.Instance.SelectedLayer);

					if (t != null) {
						SetTileAction tileAction = new SetTileAction(xt, yt, EditorEngine.Instance.SelectedLayer, tilesetIndex, -1);
						tileAction.Execute();

						action.Actions.Add(tileAction);
					}
				}

				lxt = xt;
				lyt = yt;
			}
		}

		private void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				EditorEngine.Instance.GetActionManager().Execute(this.action);
				this.action = null;
			}
		}
	}
}
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions.Tile;
using MapEditor.Data.Actions.Tile.Logic;
using MapEditor.Forms.Form_Selectors;

namespace MapEditor.States.TileEditor.Logic {
	public class LogicBucketTool : State, IState {
		public string Name {
			get { return "Logic Pen"; }
		}

		public static LogicBucketTool Instance {
			get { return Static<LogicBucketTool>.Value; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			FrmLogicTileSelector.Instance.btnBucket.Checked = true;
			FrmLogicTileSelector.Instance.btnUseSameTypeLogic.Visible = true;
			FrmLogicTileSelector.Instance.btnTools.Text = "Tool: Bucket";

			EditorForm.editorcontrol.MouseMove += onMouseMove;
			EditorForm.editorcontrol.MouseDown += onMouseDown;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			FrmLogicTileSelector.Instance.btnBucket.Checked = false;
			FrmLogicTileSelector.Instance.btnUseSameTypeLogic.Visible = false;

			EditorForm.editorcontrol.MouseMove -= onMouseMove;
			EditorForm.editorcontrol.MouseDown -= onMouseDown;
		}

		private int xt, yt;
		private int mx, my;
		private int lxt, lyt;
		private bool changed = false;

		private void onMouseMove(object sender, MouseEventArgs e) {
			processDraw(e);
		}

		public void onMouseDown(object sender, MouseEventArgs e) {
			processDraw(e);
		}

		private void processDraw(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);

				if (xt != lxt || yt != lyt) {
					changed = true;
				}

				lxt = xt;
				lyt = yt;

				if (changed) {
					int l_index = FrmLogicTileSelector.Instance.CurrentLogicIndex;
					LogicFillAction action = new LogicFillAction(xt, yt, l_index, FrmLogicTileSelector.Instance.btnUseSameTypeLogic.Checked);
					foreach (LogicSetAction aa in action.Actions) {
						foreach (SetTileAction a in aa.Actions) {
							Map map = EditorEngine.Instance.CurrentMap;

							MockupTileBehavior b = map.GetBehavior(a.X, a.Y);
							b.BehaviorId = map.Tilesets[a.TilesetIndex].Tileset.Tiles[a.TileIndex].DefaultBehavior.BehaviorId;
						}
					}
					EditorEngine.Instance.GetActionManager().Execute(action);
				}
			}

			changed = false;
		}

		public void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
		}

		public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
		}
	}
}
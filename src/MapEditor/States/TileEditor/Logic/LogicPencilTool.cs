using System;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions;
using MapEditor.Data.Actions.Tile;
using MapEditor.Data.Actions.Tile.Logic;
using MapEditor.Forms.Form_Selectors;

namespace MapEditor.States.TileEditor.Logic {
	public class LogicPencilTool : State, IState {
		private MultiAction action, temp;
		private int size = 1;

		public string Name {
			get { return "Logic Pen"; }
		}

		public static LogicPencilTool Instance {
			get { return Static<LogicPencilTool>.Value; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			FrmLogicTileSelector.Instance.btnPencil.Checked = true;
			FrmLogicTileSelector.Instance.lbSizeIndicator.Visible = true;
			FrmLogicTileSelector.Instance.btnSizeDecrease.Visible = true;
			FrmLogicTileSelector.Instance.lbSize.Visible = true;
			FrmLogicTileSelector.Instance.btnSizeIncrease.Visible = true;
			FrmLogicTileSelector.Instance.btnTools.Text = "Tool: Pencil";

			EditorForm.editorcontrol.MouseMove += onMouseMove;
			EditorForm.editorcontrol.MouseDown += onMouseDown;
			EditorForm.editorcontrol.MouseUp += onMouseUp;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			FrmLogicTileSelector.Instance.btnPencil.Checked = false;
			FrmLogicTileSelector.Instance.lbSizeIndicator.Visible = false;
			FrmLogicTileSelector.Instance.btnSizeDecrease.Visible = false;
			FrmLogicTileSelector.Instance.lbSize.Visible = false;
			FrmLogicTileSelector.Instance.btnSizeIncrease.Visible = false;

			EditorForm.editorcontrol.MouseMove -= onMouseMove;
			EditorForm.editorcontrol.MouseDown -= onMouseDown;
			EditorForm.editorcontrol.MouseUp -= onMouseUp;

			size = FrmLogicTileSelector.Instance.size;
		}

		private int xt, yt;
		private int mx, my;
		private int lxt, lyt;
		private bool changed = false;

		public void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				action = new MultiAction("Logic Pencil");
				temp = new MultiAction("customary rape action");
				processDraw(e);
			}
		}

		private void onMouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				processDraw(e);
			}
		}

		public void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				//action.UnExecute();
				temp.UnExecute();
				EditorEngine.Instance.GetActionManager().Execute(action);
				foreach (SetTileAction a in action.Actions) {
					Map map = EditorEngine.Instance.CurrentMap;

					MockupTileBehavior b = map.GetBehavior(a.X, a.Y);
					b.BehaviorId = map.Tilesets[a.TilesetIndex].Tileset.Tiles[a.TileIndex].DefaultBehavior.BehaviorId;
				}
				action = null;
				temp = null;
			}
		}

		private void processDraw(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int _size = FrmLogicTileSelector.Instance.size;
				bool odd = _size % 2 == 0;

				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);

				if (xt != lxt || yt != lyt) {
					changed = true;
				}

				lxt = xt;
				lyt = yt;

				if (changed) {
					int l_index = FrmLogicTileSelector.Instance.CurrentLogicIndex;

					int x0 = xt - (int) Math.Floor((double) _size / 2);
					int y0 = yt - (int) Math.Floor((double) _size / 2);
					int x1 = xt + (int) Math.Floor((double) _size / 2);
					int y1 = yt + (int) Math.Floor((double) _size / 2);

					MultiAction act = new MultiAction();

					for (int y = y0; !odd ? (y <= y1) : (y < y1); y++) {
						for (int x = x0; !odd ? (x <= x1) : (x < x1); x++) {
							act.Actions.Add(new LogicSetAction(x, y, l_index));
						}
					}

					act.Execute();
					temp.Actions.Add(act);

					foreach (IAction ia in act.Actions) {
						LogicSetAction i = ia as LogicSetAction;
						i.FillList();
						foreach (IAction ia2 in i.Actions) {
							action.Actions.Add(ia2);
						}
					}
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
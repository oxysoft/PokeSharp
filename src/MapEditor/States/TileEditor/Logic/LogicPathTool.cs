using System.Collections.Generic;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.Extensions;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions.Tile;
using MapEditor.Data.Actions.Tile.Logic;
using MapEditor.Forms.Form_Selectors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.States.TileEditor.Logic {
	public class LogicPathTool : State, IState {
		private int size = 3;

		public static LogicPathTool Instance {
			get { return Static<LogicPathTool>.Value; }
		}

		public string Name {
			get { return "Logic Path"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			FrmLogicTileSelector.Instance.btnPath.Checked = true;
			FrmLogicTileSelector.Instance.lbSizeIndicator.Visible = true;
			FrmLogicTileSelector.Instance.btnSizeDecrease.Visible = true;
			FrmLogicTileSelector.Instance.lbSize.Visible = true;
			FrmLogicTileSelector.Instance.btnSizeIncrease.Visible = true;
			FrmLogicTileSelector.Instance.btnTools.Text = "Tool: Path";

			EditorForm.editorcontrol.MouseDown += new MouseEventHandler(onMouseDown);
			EditorForm.editorcontrol.MouseMove += new MouseEventHandler(onMouseMove);
			EditorForm.editorcontrol.MouseUp += new MouseEventHandler(onMouseUp);

			FrmLogicTileSelector.Instance.size = size;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			FrmLogicTileSelector.Instance.btnPath.Checked = false;
			FrmLogicTileSelector.Instance.lbSizeIndicator.Visible = false;
			FrmLogicTileSelector.Instance.btnSizeDecrease.Visible = false;
			FrmLogicTileSelector.Instance.lbSize.Visible = false;
			FrmLogicTileSelector.Instance.btnSizeIncrease.Visible = false;

			EditorForm.editorcontrol.MouseDown -= new MouseEventHandler(onMouseDown);
			EditorForm.editorcontrol.MouseMove -= new MouseEventHandler(onMouseMove);
			EditorForm.editorcontrol.MouseUp -= new MouseEventHandler(onMouseUp);

			size = FrmLogicTileSelector.Instance.size = size;
		}

		private void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);
			}
		}

		private int xt = -1, yt = -1;
		private List<LogicPathSquare> path = new List<LogicPathSquare>();
		private List<Vector2> points = new List<Vector2>();

		private void onMouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int rxt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
				int ryt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);

				if (rxt != xt) {
					int dir = 0;
					if (rxt - xt == -1) dir = 2;
					if (rxt - xt == 1) dir = 3;
					if (!points.Contains(new Vector2(rxt, ryt)))
						path.Add(new LogicPathSquare(rxt, ryt, dir));
				} else if (ryt != yt) {
					int dir = 0;
					if (ryt - yt == -1) dir = 0;
					if (ryt - yt == 1) dir = 1;
					if (!points.Contains(new Vector2(rxt, ryt)))
						path.Add(new LogicPathSquare(rxt, ryt, dir));
				}

				xt = rxt;
				yt = ryt;
			}
		}

		private void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int l_index = FrmLogicTileSelector.Instance.logicViewerSelectorControl1.SelectedLogicIndex;
				for (int i = 0; i < path.Count; i++) {
					LogicPathSquare sq = path[i];
					LogicPathSquare sqm1 = null;
					if (i != 0) sqm1 = path[i - 1];
					if (sqm1 != null) {
						if ((sq.dir == 0 || sq.dir == 1) && (sqm1.dir != 0 || sqm1.dir != 1) || (sq.dir == 2 || sq.dir == 3) && (sqm1.dir != 2 || sqm1.dir != 3)) {
							path.Insert(i, new LogicPathSquare((sqm1.dir == 2 ? sqm1.x - 1 : sqm1.dir == 3 ? sqm1.x + 1 : sqm1.x), (sqm1.dir == 0 ? sqm1.y - 1 : sqm1.dir == 1 ? sqm1.y + 1 : sqm1.y), sqm1.dir));
							i++;
						}
					}
				}

				int _size = FrmLogicTileSelector.Instance.size;

				LogicPathAction action = new LogicPathAction(path, l_index, _size);
				foreach (SetTileAction a in action.Actions) {
					Map map = EditorEngine.Instance.CurrentMap;

					MockupTileBehavior b = map.GetBehavior(a.X, a.Y);
					b.BehaviorId = map.Tilesets[a.TilesetIndex].Tileset.Tiles[a.TileIndex].DefaultBehavior.BehaviorId;
				}
				EditorEngine.Instance.GetActionManager().Execute(action);
				path.Clear();
			}
		}

		public void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			SpriteBatch batch = EditorEngine.Instance.World.ViewData.SpriteBatch;
			if (batch != null) {
				foreach (LogicPathSquare sq in path) {
					float scale = EditorEngine.Instance.World.Camera.Scale;
					Vector2 scroll = EditorEngine.Instance.World.Camera.Location;

					Rectangle target = new Rectangle((int) (sq.x * 16 * scale), (int) (sq.y * 16 * scale), (int) (16 * scale), (int) (16 * scale)).Add(scroll);

					SelectionUtil.DrawRectangle(batch, Color.CornflowerBlue * .7f, target);
					SelectionUtil.DrawRectangle(batch, Color.Black * .8f, target.Add(new Vector2(1, 1)));
				}
			}
		}

		public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
		}
	}
}
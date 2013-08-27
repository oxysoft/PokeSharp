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
	public class LogicRectangleTool : State, IState {
		public LogicRectangleTool() {
			this.selection = new Selection();
		}

		public string Name {
			get { return "Logic Rectangle"; }
		}

		public static LogicRectangleTool Instance {
			get { return Static<LogicRectangleTool>.Value; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			FrmLogicTileSelector.Instance.btnRectangle.Checked = true;
			FrmLogicTileSelector.Instance.btnTools.Text = "Tool: Rectangle Fill";

			EditorForm.editorcontrol.MouseMove += onMouseMove;
			EditorForm.editorcontrol.MouseDown += onMouseDown;
			EditorForm.editorcontrol.MouseUp += onMouseUp;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			FrmLogicTileSelector.Instance.btnRectangle.Checked = false;

			EditorForm.editorcontrol.MouseMove -= onMouseMove;
			EditorForm.editorcontrol.MouseDown -= onMouseDown;
			EditorForm.editorcontrol.MouseUp -= onMouseUp;
		}

		private Selection selection;
		private bool capturedmouse = false;

		public void onMouseDown(object sender, MouseEventArgs e) {
			this.selection.MaxPosition = new Vector2(EditorEngine.Instance.CurrentMap.Width, EditorEngine.Instance.CurrentMap.Height);

			if (e.Button == MouseButtons.Left) {
				capturedmouse = true;

				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				selection.Start(new Vector2(xt, yt));
			}
		}

		private void onMouseMove(object sender, MouseEventArgs e) {
			if (capturedmouse == true) {
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				selection.End(new Vector2(xt, yt));
			}
		}

		public void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				capturedmouse = false;
				int l_index = FrmLogicTileSelector.Instance.logicViewerSelectorControl1.SelectedLogicIndex;
				Rectangle region = selection.Region;
				LogicRectangleAction action = new LogicRectangleAction(region, l_index);
				EditorEngine.Instance.GetActionManager().Execute(action);
				foreach (LogicSetAction aa in action.Actions) {
					foreach (SetTileAction a in aa.Actions) {
						Map map = EditorEngine.Instance.CurrentMap;

						MockupTileBehavior b = map.GetBehavior(a.X, a.Y);
						b.BehaviorId = map.Tilesets[a.TilesetIndex].Tileset.Tiles[a.TileIndex].DefaultBehavior.BehaviorId;
					}
				}
			}
		}

		public void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			Vector2 position = new Vector2(this.selection.Region.X, this.selection.Region.Y) * new Vector2(16, 16);
			SpriteBatch batch = EditorEngine.Instance.World.ViewData.SpriteBatch;

			if (batch != null && capturedmouse) {
				Vector2 scroll = EditorEngine.Instance.World.Camera.Location;
				float scale = EditorEngine.Instance.World.Camera.Scale;

				Rectangle target = new Rectangle((int) (position.X * scale), (int) (position.Y * scale), (int) (selection.Region.Width * 16 * scale), (int) (selection.Region.Height * 16 * scale)).Add(scroll);

				SelectionUtil.FillRectangle(batch, Color.Blue * .35f, target);
				SelectionUtil.DrawRectangle(batch, Color.Black, target.Add(new Vector2(1, 1)));
				SelectionUtil.DrawRectangle(batch, Color.White, target);
			}
		}

		public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
		}
	}
}
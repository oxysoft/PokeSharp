using System;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions;
using MapEditor.Data.Actions.Tile;
using MapEditor.Forms;
using Microsoft.Xna.Framework;

namespace MapEditor.States.TileEditor {
	public class PencilTool : State, IState {
		private MultiAction action;

		public static PencilTool Instance {
			get { return Static<PencilTool>.Value; }
		}

		public override void Initialize(FrmMainEditor mainForm) {
			base.Initialize(mainForm);
		}

		public string Name {
			get { return "PencilState"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EditorForm.b_pencil.Checked = true;

			EditorForm.editorcontrol.MouseDown += onMouseMove;
			EditorForm.editorcontrol.MouseMove += onMouseMove;
			EditorForm.editorcontrol.MouseUp += onMouseUp;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.b_pencil.Checked = false;

			EditorForm.editorcontrol.MouseDown -= onMouseMove;
			EditorForm.editorcontrol.MouseMove -= onMouseMove;
			EditorForm.editorcontrol.MouseUp -= onMouseUp;
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}

		private int lxt = -1;
		private int lyt = -1;

		private void onMouseMove(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) return;
			if (action == null) action = new MultiAction("Tile Update");

			int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale / 16);
			int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale / 16);

			if (xt != lxt || yt != lyt) {
				if (TileEditorState.Instance.SelectedRegion != Rectangle.Empty) {
					MultiAction multiAction = new MultiAction("Tile Update");
					Rectangle selection = TileEditorState.Instance.SelectedRegion;

					for (int x = 0; x < selection.Width; x++) {
						for (int y = 0; y < selection.Height; y++) {
							int currentX = selection.X + x;
							int currentY = selection.Y + y;

							int tilesetIndex = TileEditorState.Instance.SelectedTileset;

							Tileset tilesheet = EditorEngine.Instance.CurrentMap.Tilesets[tilesetIndex].Tileset;
							int tileIndex = tilesheet.Texture.GetIndex(currentX, currentY);

							int zt = EditorEngine.Instance.SelectedLayer;
							MockupTile t = EditorEngine.Instance.CurrentMap.GetTile(xt + x, yt + y, zt);

							if (t == null) continue;

							SetTileAction tileAction = new SetTileAction(
								xt + x, yt + y,
								zt,
								tilesetIndex,
								tileIndex);
							multiAction.Actions.Add(tileAction);
						}
					}

					multiAction.Execute();
					action.Actions.Add(multiAction);
				}
			}

			lxt = xt;
			lyt = yt;
		}

		private void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				action.UnExecute();
				EditorEngine.Instance.GetActionManager().Execute(action);
				foreach (MultiAction aa in action.Actions) {
					foreach (SetTileAction a in aa.Actions) {
						Map map = EditorEngine.Instance.CurrentMap;

						MockupTileBehavior b = map.GetBehavior(a.X, a.Y);
						b.BehaviorId = map.Tilesets[a.TilesetIndex].Tileset.Tiles[a.TileIndex].DefaultBehavior.BehaviorId;
					}
				}
				action = null;
			}
		}
	}
}
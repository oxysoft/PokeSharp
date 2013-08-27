using System;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.Extensions;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions;
using MapEditor.Data.Actions.Tile;
using MapEditor.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.States.TileEditor {
	public class RectangleTool : State, IState {
		private Selection selection;
		private bool active = false;

		public static RectangleTool Instance {
			get { return Static<RectangleTool>.Value; }
		}

		public override void Initialize(FrmMainEditor mainForm) {
			this.selection = new Selection();
			base.Initialize(mainForm);
		}

		public string Name {
			get { return "RectangleState"; }
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.EditorForm.b_rectangle.Checked = true;

			this.EditorForm.editorcontrol.MouseMove += onMouseMove;
			this.EditorForm.editorcontrol.MouseDown += onMouseDown;
			this.EditorForm.editorcontrol.MouseUp += onMouseUp;
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			this.EditorForm.b_rectangle.Checked = false;

			this.EditorForm.editorcontrol.MouseMove -= onMouseMove;
			this.EditorForm.editorcontrol.MouseDown -= onMouseDown;
			this.EditorForm.editorcontrol.MouseUp -= onMouseUp;
		}

		public void Draw(GameTime gameTime) {
			SpriteBatch spriteBatch = EditorEngine.Instance.World.ViewData.SpriteBatch;
			Rectangle target = selection.Region;
			Rectangle source = TileEditorState.Instance.SelectedRegion;
			Tileset tileset = EditorEngine.Instance.CurrentMap.Tilesets[TileEditorState.Instance.SelectedTileset].Tileset;

			if (!this.active) return;

			if (source.Width > 0 && source.Height > 0) {
				int sx = 0;
				int sy = 0;

				for (int x = 0; x < target.Width; x++) {
					if (x % source.Width == 0) {
						sx = 0;
					}
					for (int y = 0; y < target.Height; y++) {
						if (y % source.Height == 0) {
							sy = 0;
						}

						int xt = target.X + x;
						int yt = target.Y + y;

						Vector2 scroll = EditorEngine.Instance.World.Camera.Location;
						float scale = EditorEngine.Instance.World.Camera.Scale;

						Rectangle drawTarget = new Rectangle((int) (xt * 16 * scale), (int) (yt * 16 * scale), (int) (16 * scale), (int) (16 * scale)).Add(scroll);
						Rectangle drawSource = tileset.Texture.GetSource(tileset.Texture.GetIndex(source.X + sx, source.Y + sy));

						spriteBatch.Draw(tileset.Texture.Texture, drawTarget, drawSource, Color.White);
						sy++;
					}
					sx++;
				}
			}
		}

		public void Update(GameTime gameTime) {
			this.selection.MaxPosition = new Vector2(
				EditorEngine.Instance.CurrentMap.Width,
				EditorEngine.Instance.CurrentMap.Height);
		}

		private void onMouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				selection.Start(new Vector2(xt, yt));

				active = true;
			}
		}

		private void onMouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xt = (int) ((e.X - EditorEngine.Instance.xCam) / EditorEngine.Instance.World.Camera.Scale);
				int yt = (int) ((e.Y - EditorEngine.Instance.yCam) / EditorEngine.Instance.World.Camera.Scale);

				selection.End(new Vector2(xt, yt));
			}
		}

		private void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				Rectangle region = selection.Region;
				Rectangle tileRegion = TileEditorState.Instance.SelectedRegion;

				RectangleAction action = new RectangleAction(tileRegion, region, TileEditorState.Instance.SelectedTileset);
				EditorEngine.Instance.GetActionManager().Execute(action);
				foreach (SetTileAction a in action.Actions) {
					Map map = EditorEngine.Instance.CurrentMap;

					MockupTileBehavior b = map.GetBehavior(a.X, a.Y);
					b.BehaviorId = map.Tilesets[a.TilesetIndex].Tileset.Tiles[a.TileIndex].DefaultBehavior.BehaviorId;
				}
				active = false;
			}
		}
	}
}
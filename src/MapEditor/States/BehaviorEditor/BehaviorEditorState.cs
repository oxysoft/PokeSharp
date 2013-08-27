using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Text.Fonts;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.Extensions;
using General.States;
using MapEditor.Data;
using MapEditor.Forms.Form_Selectors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.States.BehaviorEditor {
	public class BehaviorEditorState : State, IState {
		public static BehaviorEditorState Instance {
			get { return Static<BehaviorEditorState>.Value; }
		}

		private Dictionary<Color, Texture2D> colors;

		public BehaviorEditorState() {
			this.colors = new Dictionary<Color, Texture2D>();
			this.ToolMachine = new FiniteStateMachine();
		}

		public string Name {
			get { return "EventEditorState"; }
		}

		public FiniteStateMachine ToolMachine { get; private set; }

		public byte SelectedTileBehaviorId {
			get { return FrmTileBehaviorSelector.Instance.SelectedBehaviorId; }
		}

		public override void Initialize(Forms.FrmMainEditor mainForm) {
			base.Initialize(mainForm);
			TileBehaviorTool.Instance.Initialize(mainForm);
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			FrmTileBehaviorSelector.Instance.TopLevel = false;
			FrmTileBehaviorSelector.Instance.FormBorderStyle = FormBorderStyle.None;
			FrmTileBehaviorSelector.Instance.Dock = DockStyle.Fill;
			FrmTileBehaviorSelector.Instance.Visible = true;
			EditorForm.splitContainer1.Panel1.Controls.Add(FrmTileBehaviorSelector.Instance);

			this.ToolMachine.ChangeState(TileBehaviorTool.Instance);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			this.ToolMachine.State.Leave(this.ToolMachine, null);
			EditorForm.splitContainer1.Panel1.Controls.Clear();
		}

		public void Draw(GameTime gameTime) {
			int w = EditorEngine.Instance.CurrentMap.Width;
			int h = EditorEngine.Instance.CurrentMap.Height;
			int xs = EditorEngine.Instance.xCam;
			int ys = EditorEngine.Instance.yCam;

			Map m = EditorEngine.Instance.CurrentMap;
			SpriteBatch spriteBatch = m.World.ViewData.SpriteBatch;

			for (int yt = 0; yt < m.Height; yt++) {
				for (int xt = 0; xt < m.Width; xt++) {
					MockupTileBehavior _ref = m.GetBehavior(xt, yt);
					Texture2D pixel;

					if (!colors.ContainsKey(_ref.TileBehavior.Color)) {
						pixel = new Texture2D(EditorEngine.Instance.GraphicsDevice, 1, 1);
						pixel.SetData<Color>(new Color[] {_ref.TileBehavior.Color});
						colors.Add(_ref.TileBehavior.Color, pixel);
					}

					pixel = colors[_ref.TileBehavior.Color];
					Vector2 scroll = m.World.Camera.Location;
					float scale = m.World.Camera.Scale;
					const float opacity = .71f;

					Rectangle target = new Rectangle((int) (xt * 16 * scale), (int) (yt * 16 * scale), (int) (16 * scale), (int) (16 * scale)).Add(scroll);
					Rectangle targetFont = new Rectangle((int) ((xt * 16 + 16 / 2f - Math.Floor(FontRenderer.Instance.Width(_ref.TileBehavior.Identifier, 2) / 2f)) * scale), (int) ((yt * 16 + 14) * scale), (int) (16 * scale), (int) (16 * scale)).Add(scroll);
					spriteBatch.Draw(pixel, target, Color.White * opacity);
					FontRenderer.Instance.Draw(spriteBatch, _ref.TileBehavior.Identifier, 2, targetFont.X, targetFont.Y, opacity);
				}
			}

			this.ToolMachine.Draw(gameTime);
		}

		public void Update(GameTime gameTime) {
			this.ToolMachine.Update(gameTime);
		}
	}
}
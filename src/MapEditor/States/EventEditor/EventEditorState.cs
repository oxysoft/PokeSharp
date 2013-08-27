using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Selections;
using GameEngine.Data.Common;
using General.Common;
using General.States;
using MapEditor.Data;
using Microsoft.Xna.Framework;

namespace MapEditor.States.EventEditor {
	public class EventEditorState : State, IState {
		public EventEditorState() {
			this.ToolMachine = new FiniteStateMachine();
		}

		public string Name {
			get { return "EventEditorState"; }
		}

		public FiniteStateMachine ToolMachine { get; private set; }

		public static EventEditorState Instance {
			get { return Static<EventEditorState>.Value; }
		}

		public override void Initialize(Forms.FrmMainEditor mainForm) {
			base.Initialize(mainForm);
			EventTool.Instance.Initialize(mainForm);
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.ToolMachine.ChangeState(EventTool.Instance);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
		}

		public void Draw(GameTime gameTime) {
			int w = EditorEngine.Instance.CurrentMap.Width;
			int h = EditorEngine.Instance.CurrentMap.Height;
			int xs = EditorEngine.Instance.xCam;
			int ys = EditorEngine.Instance.yCam;

			//Columns
			for (int x = 0; x < w; x++) {
				SelectionUtil.DrawStraightLine(EditorEngine.Instance.World.ViewData.SpriteBatch, Color.Black, 0.6f, (x << 4) + xs, ys, 2, h << 4);
			}

			//Rows
			for (int y = 0; y < h; y++) {
				SelectionUtil.DrawStraightLine(EditorEngine.Instance.World.ViewData.SpriteBatch, Color.Black, 0.6f, xs, (y << 4) + ys, 1, w << 4);
			}

			this.ToolMachine.Draw(gameTime);
		}

		public void Update(GameTime gameTime) {
			this.ToolMachine.Update(gameTime);
		}
	}
}
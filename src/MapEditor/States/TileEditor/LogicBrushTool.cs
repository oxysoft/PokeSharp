using System.Windows.Forms;
using AeonEditor.Forms;
using General.Common;
using General.States;
using MapEditor.Forms;
using MapEditor.Forms.Form_Selectors;
using MapEditor.States.TileEditor.Logic;

namespace MapEditor.States.TileEditor {
	public class LogicBrushTool : State, IState, IFiniteStateMachine {

		IState previousState;
		IState currentState;

		public static LogicBrushTool Instance {
			get {
				return Static<LogicBrushTool>.Value;
			}
		}

		public string Name {
			get {
				return "Logic Brush";
			}
		}

		public override void Initialize(FrmMainEditor frm) {
			base.Initialize(frm);

			LogicPencilTool.Instance.Initialize(frm);
			LogicBucketTool.Instance.Initialize(frm);
			LogicRectangleTool.Instance.Initialize(frm);
			LogicPathTool.Instance.Initialize(frm);
		}

		public void ChangeState(IState state) {
			if (currentState != null) {
				currentState.Leave(this, state);
			}
			state.Enter(this, currentState);

			this.previousState = currentState;
			this.currentState = state;
		}

		public void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			if (currentState != null) {
				currentState.Draw(gameTime);
			}
		}

		public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			if (currentState != null) {
				currentState.Update(gameTime);
			}
		}

		Control oldcontrol;

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.EditorForm.b_logic.Checked = true;

			oldcontrol = EditorForm.splitContainer1.Panel1.Controls[0];

			FrmLogicTileSelector.Instance.TopLevel = false;
			FrmLogicTileSelector.Instance.FormBorderStyle = FormBorderStyle.None;
			FrmLogicTileSelector.Instance.Dock = DockStyle.Fill;
			FrmLogicTileSelector.Instance.Visible = true;
			EditorForm.splitContainer1.Panel1.Controls.Clear();
			EditorForm.splitContainer1.Panel1.Controls.Add(FrmLogicTileSelector.Instance);

			ChangeState(LogicPencilTool.Instance);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			this.EditorForm.b_logic.Checked = false;

			FrmLogicTileSelector.Instance.Hide();
			FrmTilesetSelector.Instance.Show();

			EditorForm.splitContainer1.Panel1.Controls.Clear();
			EditorForm.splitContainer1.Panel1.Controls.Add(oldcontrol);

			if (currentState != null) {
				this.currentState.Leave(this, null);
			}
		}
	}
}

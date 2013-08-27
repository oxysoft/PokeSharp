using System.Windows.Forms;
using AeonEditor.Forms;
using General.Common;
using General.States;
using MapEditor.Forms;
using MapEditor.States.General;
using Microsoft.Xna.Framework;

namespace MapEditor.States.EntityEditor {
	public class EntityEditorState : State, IState {
		public EntityEditorState() {
			this.ToolStates = new FiniteStateMachine();
		}
		
		public string Name {
			get {
				return "EntityEditorState";
			}
		}

		public FiniteStateMachine ToolStates {
			get;
			private set;
		}

		public static EntityEditorState Instance {
			get {
				return Static<EntityEditorState>.Value;
			}
		}

		public override void Initialize(FrmMainEditor mainForm) {
			base.Initialize(mainForm);

			EntityAddTool.Instance.Initialize(mainForm);
			EntitySelectionTool.Instance.Initialize(mainForm);
			EntityRectangleTool.Instance.Initialize(mainForm);
			EntityMoveTool.Instance.Initialize(mainForm);
			EntitySelectAllTool.Instance.Initialize(mainForm);
			EntityRemoveTool.Instance.Initialize(mainForm);
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.EditorForm.bEntities.Checked = true;
			this.EditorForm.b_hand.Visible = true;
			this.EditorForm.b_entityadd.Visible = true;
			this.EditorForm.b_entityrectangle.Visible = true;
			this.EditorForm.b_entitymove.Visible = true;
			this.EditorForm.b_entityremove.Visible = true;
			this.EditorForm.b_entityselect.Visible = true;
			this.EditorForm.b_entityselectall.Visible = true;

			FrmEntitySelector.Instance.TopLevel = false;
			FrmEntitySelector.Instance.FormBorderStyle = FormBorderStyle.None;
			FrmEntitySelector.Instance.Dock = DockStyle.Fill;
			FrmEntitySelector.Instance.Visible = true;
			EditorForm.splitContainer1.Panel1.Controls.Clear();
			EditorForm.splitContainer1.Panel1.Controls.Add(FrmEntitySelector.Instance);

			this.ToolStates.ChangeState(MoveTool.Instance);
			this.EditorForm.Focus();
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			this.EditorForm.bEntities.Checked = false;
			this.EditorForm.b_hand.Visible = false;
			this.EditorForm.b_entityadd.Visible = false;
			this.EditorForm.b_entityrectangle.Visible = false;
			this.EditorForm.b_entitymove.Visible = false;
			this.EditorForm.b_entityremove.Visible = false;
			this.EditorForm.b_entityselect.Visible = false;
			this.EditorForm.b_entityselectall.Visible = false;
			this.EditorForm.lbLayer.Visible = false;

			EditorForm.splitContainer1.Panel1.Controls.Clear();

			this.ToolStates.State.Leave(stateMachine, newState);
		}

		public void Draw(GameTime gameTime) {
			this.ToolStates.Draw(gameTime);
		}

		public void Update(GameTime gameTime) {
			this.ToolStates.Update(gameTime);
		}

	}
}

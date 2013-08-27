using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General.Common;
using General.States;
using MapEditor.Forms.Form_Selectors;
using Microsoft.Xna.Framework;

namespace MapEditor.States.PermissionEditor {
	public class PermissionEditorState : State, IState {
		public static PermissionEditorState Instance {
			get { return Static<PermissionEditorState>.Value; }
		}

		public string Name { get; private set; }
		public FiniteStateMachine ToolMachine { get; set; }

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			FrmTileBehaviorSelector.Instance.TopLevel = false;
			FrmTileBehaviorSelector.Instance.FormBorderStyle = FormBorderStyle.None;
			FrmTileBehaviorSelector.Instance.Dock = DockStyle.Fill;
			FrmTileBehaviorSelector.Instance.Visible = true;
			EditorForm.splitContainer1.Panel1.Controls.Add(FrmTileBehaviorSelector.Instance);

			this.ToolMachine.ChangeState(PermissionTool.Instance);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}
	}
}
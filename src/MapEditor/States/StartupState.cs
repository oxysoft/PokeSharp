using System.Windows.Forms;
using AeonEditor.Forms;
using General.Common;
using General.States;
using MapEditor.Forms;
using MapEditor.States.General;
using Microsoft.Xna.Framework;

namespace MapEditor.States {
	public class StartupState : State, IState {
		#region Properties
		public static StartupState Instance {
			get {
				return Static<StartupState>.Value;
			}
		}
		#endregion

		public string Name {
			get {
				return "Startup";
			}
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			MoveTool.Instance.Initialize(EditorForm);

			FrmTilesetSelector.Instance.TopLevel = false;
			FrmTilesetSelector.Instance.FormBorderStyle = FormBorderStyle.None;
			FrmTilesetSelector.Instance.Dock = DockStyle.Fill;
			FrmTilesetSelector.Instance.Visible = true;
			EditorForm.splitContainer1.Panel1.Controls.Clear();
			EditorForm.splitContainer1.Panel1.Controls.Add(FrmTilesetSelector.Instance);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			/*this.MainForm.mSave.Enabled = true;
			this.MainForm.mSaveAs.Enabled = true;
			this.MainForm.mCompile.Enabled = true;
			this.MainForm.mExportImage.Enabled = true;

			this.MainForm.verticalScrollBar.Visible = true;
			this.MainForm.horizontalScrollBar.Visible = true;

			this.MainForm.tSave.Enabled = true;

			this.MainForm.tUndo.Enabled = true;
			this.MainForm.tRedo.Enabled = true;
			this.MainForm.tActions.Enabled = true;

			this.MainForm.tTiles.Enabled = true;
			this.MainForm.tEntities.Enabled = true;
			this.MainForm.tScripts.Enabled = true;

			this.MainForm.tProperties.Enabled = true;
			this.MainForm.mProperties.Enabled = true;*/
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}
	}
}

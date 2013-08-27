using System;
using System.Windows.Forms;
using General.Common;
using MapEditor.Data;
using MapEditor.Data.Actions;

namespace MapEditor.Forms {
	public partial class FrmUndoRedoList : Form {

		ActionManager ActionManager;

		public static FrmUndoRedoList Instance {
			get {
				return Static<FrmUndoRedoList>.Value;
			}
		}

		public FrmUndoRedoList() {
			InitializeComponent();
		}

		public void MapSwapped() {
			if (ActionManager != null) {
				ActionManager.Changed -= new EventHandler(onActionExecuted);
				ActionManager.ExecuteUndo -= new EventHandler(onUndo);
				ActionManager.ExecuteRedo -= new EventHandler(onRedo);
			}

			ActionManager = EditorEngine.Instance.GetActionManager();

			ActionManager.Changed += new EventHandler(onActionExecuted);
			ActionManager.ExecuteUndo += new EventHandler(onUndo);
			ActionManager.ExecuteRedo += new EventHandler(onRedo);

			listActions.Items.Clear();

			foreach (IAction action in EditorEngine.Instance.GetActionManager().Actions) {
				ListViewItem result = new ListViewItem(action.Name);
				result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, action.Time.ToString()));
				result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, "" + 1337));
				listActions.Items.Add(result);
			}
		}

		private void FrmUndoRedoList_Shown(object sender, EventArgs e) {
			listActions.Items.Clear();

			foreach (IAction action in EditorEngine.Instance.GetActionManager().Actions) {
				ListViewItem result = new ListViewItem(action.Name);
				result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, action.Time.ToString()));
				result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, "" + 1337));
				listActions.Items.Add(result);
			}
		}

		private void onActionExecuted(object sender, EventArgs e) {
			listActions.Items.Clear();

			foreach (IAction action in EditorEngine.Instance.GetActionManager().Actions) {
				ListViewItem result = new ListViewItem(action.Name);
				result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, action.Time.ToString()));
				result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, "" + 1337));
				listActions.Items.Add(result);
			}
		}

		public void onUndo(object sender, EventArgs e) {
			listActions.Items.RemoveAt(listActions.Items.Count - 1);
		}

		public void onRedo(object sender, EventArgs e) {
			IAction action = EditorEngine.Instance.GetActionManager().Actions[EditorEngine.Instance.GetActionManager().Actions.Count - 1];
			ListViewItem result = new ListViewItem(action.Name);
			result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, action.Time.ToString()));
			result.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem(result, "" + 1337));
			listActions.Items.Add(result);
		}

		private void FrmUndoRedoList_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			this.Hide();
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
			ActionManager.Undo();
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e) {
			ActionManager.Redo();
		}

		private void replayAllToolStripMenuItem_Click(object sender, EventArgs e) {
			ActionManager.ReplayAll();
		}

	}
}

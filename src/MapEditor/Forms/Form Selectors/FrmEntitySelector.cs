using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AeonEditor.Forms;
using GameEngine.Data.Entities.Core;
using General.Common;
using MapEditor.States.EntityEditor;

namespace MapEditor.Forms {
	public partial class FrmEntitySelector : Form {
		public FrmEntitySelector() {
			InitializeComponent();
			entityViewerSelectorControl1.initialize(vScrollBar1);
			entityViewerSelectorControl1.onTemplateSelected += new EventHandler(templateSelected);
		}

		public static FrmEntitySelector Instance {
			get {
				return Static<FrmEntitySelector>.Value;
			}
		}

		public EntityTemplate selectedEntity {
			get {
				return entityViewerSelectorControl1.SelectedEntity;
			}
		}

		private void FrmEntitySelector_VisibleChanged(object sender, EventArgs e) {
			this.Location = FrmTilesetSelector.Instance.Location;
		}

		private void FrmEntitySelector_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}

		private void templateSelected(object s, EventArgs e) {
			EntityEditorState.Instance.ToolStates.ChangeState(EntityAddTool.Instance);
		}

		
	}
}

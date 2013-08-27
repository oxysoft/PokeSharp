using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.Data;

namespace MapEditor.Forms {
	public partial class FrmSettings : Form {
		public string DefProjLoc {
			get { return tbDefProjLoc.Text; }
			set { tbDefProjLoc.Text = value; }
		}

		public FrmSettings() {
			InitializeComponent();
		}
		
		private void FrmSettings_Load(object sender, EventArgs e) {
			DefProjLoc = Options.Instance.DefaultProject;
		}

		private void btnOk_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void btnDefProjLoc_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = "(*.psproj)|*.psproj";
				if (dialog.ShowDialog() == DialogResult.OK) {
					tbDefProjLoc.Text = dialog.FileName;
				}
			}
		}

	}
}
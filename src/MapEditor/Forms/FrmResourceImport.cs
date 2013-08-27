using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor.Forms {
	public partial class FrmResourceImport : Form {
		public int Mode {
			get {
				if (rbOption1.Checked) return 0;
				else if (rbOption2.Checked) return 1;
				return -1;
			}
		}

		public FrmResourceImport() {
			InitializeComponent();
		}

		private void bOk_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void optionSelected(object sender, EventArgs e) {
			bOk.Enabled = true;
		}
	}
}
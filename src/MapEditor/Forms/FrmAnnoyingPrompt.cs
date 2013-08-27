using System;
using System.Windows.Forms;

namespace MapEditor.Forms {
	public partial class FrmAnnoyingPrompt : Form {
		public FrmAnnoyingPrompt() {
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}

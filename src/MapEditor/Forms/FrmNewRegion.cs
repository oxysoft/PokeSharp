using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AeonEditor.Forms {
	public partial class FrmNewRegion : Form {
		public FrmNewRegion() {
			InitializeComponent();
		}

		public string RegionName {
			get {
				return (string) tbRegionName.Text;
			}
		}

		public string RegionAuthor {
			get {
				return (string)tbRegionAuthor.Text;
			}
		}

		private void btnOk_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}
	}
}

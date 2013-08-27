using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Data.Common;

namespace MapEditor.Forms {
	public partial class FrmGameTest : Form {
		private World testWorld;

		public FrmGameTest(World testWorld) {
			this.testWorld = testWorld;
			InitializeComponent();
		}
	}
}
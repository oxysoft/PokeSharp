using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;

namespace MapEditor.Forms.Form_Selectors {
	public partial class FrmTileBehaviorSelector : Form {

		public static FrmTileBehaviorSelector Instance {
			get {
				return Static<FrmTileBehaviorSelector>.Value;
			}
		}

		public FrmTileBehaviorSelector() {
			InitializeComponent();
		}

		public TileBehavior SelectedBehavior {
			get {
				return this.control.Selected;
			}
		}
		public byte SelectedBehaviorId {
			get {
				return this.control.SelectedId;
			}
		}
	}
}

using System.Drawing;
using System.Windows.Forms;

namespace MapEditor.UI.Old.Common {
	public class DialogPanel : Panel {

		public DialogPanel() {
			this.DoubleBuffered = true;

			this.BackColor = Color.FromArgb(0x80, 0x80, 0x80);
		}
		
		protected override void OnPaint(PaintEventArgs e) {
			GraphicsHelper helper = new GraphicsHelper(e.Graphics);

			helper.Gradient(UColor.Blend(0x30, UColor.Black), UColor.Transparent, new Rectangle(0, 0, this.Width, this.Height / 2), 90);
			helper.Line(UColor.Blend(0x60, UColor.Black), 0, 0, this.Width, 0);
		}

	}
}

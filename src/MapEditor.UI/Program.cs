using System.Windows.Forms;

namespace MapEditor.UI {
	public class Program {

		public static void Main(string[] args) {
			using (TestForm form = new TestForm()) {
				Application.EnableVisualStyles();
				Application.Run(form);
			}
		}

	}
}

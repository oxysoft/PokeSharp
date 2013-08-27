using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Data.Text {
	public class LineInfo {
		public int SelectionStart, SelectionEnd;
		public string Text;

		public LineInfo(string s) {
			this.Text = s;
		}

		/// <summary>
		/// Write the string 's' at the caret's position
		/// </summary>
		/// <param name="s">The text to write</param>
		public void Write(string s) {
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s">Write the string 's' at the end of the string</param>
		public void Append(string s) {
			Text += s;
		}
	}
}

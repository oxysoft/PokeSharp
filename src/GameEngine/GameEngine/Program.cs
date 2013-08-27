using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
	public class Program {
		public static void Main(string[] args) {
			using (Data.GameEngine engine = new Data.GameEngine()) {
				engine.Run();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Data.Debugging {
	public interface ICommand {
		string Identifier { get; }
		void Execute(params string[] splitted);
	}
}
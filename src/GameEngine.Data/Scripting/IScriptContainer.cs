using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Data.Scripting {
	public interface IScriptContainer {
		string Code { get; set; }
		string DefaultCode();
	}
}
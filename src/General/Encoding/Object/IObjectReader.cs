using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Encoding.Object {
	public interface IObjectReader<T> {
		T Read();
	}
}

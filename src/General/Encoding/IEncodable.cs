using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Encoding;

namespace General.Common {
	public interface IEncodable {
		void Encode(BinaryOutput stream);
		IEncodable Decode(BinaryInput stream);
	}
}

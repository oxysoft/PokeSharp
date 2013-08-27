using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Encoding.Object;

namespace General.Encoding.BackwardCompatibility {
	public class NamedVariableIO : IObjectIO<NamedVariable> {
		public NamedVariableIO(IBinaryIO _stream) {
			this._stream = _stream;
		}

		private IBinaryIO _stream;

		public void Write(NamedVariable t) {
			BinaryOutput stream = _stream as BinaryOutput;

			int type = 0;

			if (t is NamedBoolean) type = 1;
			else if (t is NamedByte) type = 2;
			else if (t is NamedChar) type = 3;
			else if (t is NamedDecimal) type = 4;
			else if (t is NamedDouble) type = 5;
			else if (t is NamedInt16) type = 6;
			else if (t is NamedInt32) type = 7;
			else if (t is NamedInt64) type = 8;
			else if (t is NamedSByte) type = 9;
			else if (t is NamedSingle) type = 10;
			else if (t is NamedString) type = 11;
			else if (t is NamedUInt16) type = 12;
			else if (t is NamedUInt32) type = 13;
			else if (t is NamedUInt64) type = 14;

			stream.Write(type);
			stream.Write(t);
		}

		public NamedVariable Read() {
			BinaryInput stream = _stream as BinaryInput;

			int type = stream.ReadInt32();

			if (type == 1) return stream.ReadObject<NamedBoolean>();
			else if (type == 2) return stream.ReadObject<NamedByte>();
			else if (type == 3) return stream.ReadObject<NamedChar>();
			else if (type == 4) return stream.ReadObject<NamedDecimal>();
			else if (type == 5) return stream.ReadObject<NamedDouble>();
			else if (type == 6) return stream.ReadObject<NamedInt16>();
			else if (type == 7) return stream.ReadObject<NamedInt32>();
			else if (type == 8) return stream.ReadObject<NamedInt64>();
			else if (type == 9) return stream.ReadObject<NamedSByte>();
			else if (type == 10) return stream.ReadObject<NamedSingle>();
			else if (type == 11) return stream.ReadObject<NamedString>();
			else if (type == 12) return stream.ReadObject<NamedUInt16>();
			else if (type == 13) return stream.ReadObject<NamedUInt32>();
			else if (type == 14) return stream.ReadObject<NamedUInt64>();

			return null;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;

namespace General.Encoding.BackwardCompatibility {
	public class NamedCompound : IEncodable {
		public string Name;
		public List<IEncodable> Tokens;

		public NamedCompound() {
			this.Tokens = new List<IEncodable>();
		}

		public NamedCompound(string name) : this() {
			this.Name = name;
		}

		public void AddToken() {
		}

		public IEncodable GetToken(string name) {
			foreach (IEncodable encodable in Tokens) {
			}
			return null;
		}

		public static NamedCompound DecodeCompound(BinaryInput stream, List<Tuple<string, Type>> GenericChute) {
			NamedCompound result = new NamedCompound();
			result.Name = stream.ReadString();
			int c = stream.ReadInt32();
			NamedVariableIO io = new NamedVariableIO(stream);
			for (int i = 0; i < c; i++) {
				NamedVariable varag= io.Read();
				if (varag != null) result.Tokens.Add(varag);
				else {
					string n = stream.ReadString();
					Type type = null;
					foreach (Tuple<string, Type> t in GenericChute.Where(t => n == t.Item1)) {
						type = t.Item2;
					}
					if (type != null) {
					}
				}
			}
			return result;
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(Name);
			stream.Write(Tokens.Count);
			NamedVariableIO io = new NamedVariableIO(stream);
			foreach (IEncodable token in Tokens) {
				if (token is NamedVariable) {
					io.Write(token as NamedVariable);
				} else {
					stream.Write(-1);
					stream.Write(token);
				}
			}
		}

		public IEncodable Decode(BinaryInput stream) {
			return this;
		}
	}
}
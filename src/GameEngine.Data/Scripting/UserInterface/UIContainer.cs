using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Encoding;

namespace GameEngine.Data.Scripting.UserInterface {
	public class UIContainer : List<UITemplate>, IEncodable {
		public UITemplate Get(string name) {
			return this.FirstOrDefault(temp => temp.Name == name);
		}

		public UITemplate Get(UITemplate template) {
			return this.FirstOrDefault(temp => temp.Equals(template));
		}

		public bool NameTaken(string name) {
			return this.Any(temp => temp.Name == name);
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(this.Count);
			foreach (UITemplate template in this) {
				template.Encode(stream);
			}
		}

		public IEncodable Decode(BinaryInput stream) {
			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				Add(stream.ReadObject<UITemplate>());
			}
			return this;
		}
	}
}
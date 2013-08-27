using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Encoding;

namespace GameEngine.Data.Tiles {
	public class TilesetFactory : IEncodable {
		private int currentId;

		public int AllocateID() {
			return currentId++;
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(this.currentId);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.currentId = stream.ReadInt32();
			return this;
		}
	}
}
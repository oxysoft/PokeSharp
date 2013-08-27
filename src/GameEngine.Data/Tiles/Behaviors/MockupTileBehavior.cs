using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Encoding;

namespace GameEngine.Data.Tiles.Behaviors {
	public class MockupTileBehavior : IEncodable {
		private byte behaviorId;

		public byte BehaviorId {
			get { return behaviorId; }
			set {
				behaviorId = value;
			}
		}

		public MockupTileBehavior() {
		}

		public MockupTileBehavior(byte id) {
			this.BehaviorId = id;
		}

		public MockupTileBehavior(TileBehavior baseT) {
			this.BehaviorId = baseT.Id;
		}

		public TileBehavior TileBehavior {
			get { return TileBehavior.Values.Get(this.BehaviorId); }
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(BehaviorId);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.BehaviorId = stream.ReadByte();
			return this;
		}
	}
}
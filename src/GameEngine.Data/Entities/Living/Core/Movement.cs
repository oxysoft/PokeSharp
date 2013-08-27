using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Encoding;

namespace GameEngine.Data.Entities.Living.Core {
	public class Movement : IEncodable {
		public Facing Facing;
		public MovementSpeed Speed;

		public Movement() {
		}

		public Movement(Facing direction, MovementSpeed speed) {
			this.Facing = direction;
			this.Speed = speed;
		}

		public void Encode(BinaryOutput stream) {
			stream.Write((byte) Facing);
			stream.Write((byte) Speed);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Facing = (Facing) stream.ReadByte();
			this.Speed = (MovementSpeed) stream.ReadByte();
			return this;
		}
	}
}

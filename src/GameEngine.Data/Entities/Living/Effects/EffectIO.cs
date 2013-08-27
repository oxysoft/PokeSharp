using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Encoding;
using General.Encoding.Object;

namespace GameEngine.Data.Entities.Living.Effects {
	public class EffectIO : IObjectIO<IEffect> {
	
		private IBinaryIO _stream;

		public EffectIO(IBinaryIO stream) {
			this._stream = stream;
		}

		public void Write(IEffect t) {
			BinaryOutput stream = this._stream as BinaryOutput;
			byte type = 0;
			if (t is LockEffect) {
				type = 0;
			}
			stream.Write(type);
			stream.Write(t);
		}

		public IEffect Read() {
			BinaryInput stream = this._stream as BinaryInput;
			int type = stream.ReadByte();
			if (type == 0) return stream.ReadObject<LockEffect>();
			return null;
		}
	}
}

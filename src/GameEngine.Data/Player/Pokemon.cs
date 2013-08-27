using General.Common;
using General.Encoding;

namespace GameEngine.Data.Player {
	public class Pokemon : IEncodable {
		public void Encode(BinaryOutput stream) {
		}

		public IEncodable Decode(BinaryInput stream) {
			return this;
		}
	}
}

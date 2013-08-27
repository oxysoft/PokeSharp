using General.Common;
using General.Encoding;
using General.Encoding.Object;
using MapEditor.Data.Actions.Tile;
using MapEditor.Data.Actions.Object;

namespace MapEditor.Data.Actions {
	public class ActionIO : IObjectIO<IAction> {

		public ActionIO(IBinaryIO _stream) {
			this._stream = _stream;
		}

		IBinaryIO _stream;

		public void Write(IAction t) {

			BinaryOutput stream = _stream as BinaryOutput;

			int i = 0;
			if (t is SetTileAction) {
				i = 1;
			}
			if (t is MultiAction) {
				i = 2;
			}
			if (t is FillAction) {
				i = 3;
			}
			if (t is RectangleAction) {
				i = 4;
			}
			if (t is AddEntityAction) {
				i = 5;
			}
			if (t is RemoveEntityAction) {
				i = 6;
			}

			stream.Write(i);

			IEncodable encodable = t as IEncodable;
			if (encodable != null) {
				encodable.Encode(stream);
			}
		}

		public IAction Read() {
			IAction result = null;
			BinaryInput stream = _stream as BinaryInput;
			int i = stream.ReadInt32();

			if (i == 1) {
				result = new SetTileAction();
			}
			if (i == 2) {
				result = new MultiAction();
			}
			if (i == 3) {
				result = new FillAction();
			}
			if (i == 4) {
				result = new RectangleAction();
			}
			if (i == 5) {
				result = new AddEntityAction();
			}
			if (i == 6) {
				result = new RemoveEntityAction();
			}

			IEncodable encodable = result as IEncodable;
			if (encodable != null) {
				encodable.Decode(stream);
			}
			return result;
		}
	}
}

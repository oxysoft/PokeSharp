using GameEngine.Data.Entities.Types;
using GameEngine.Data.Entities.World;
using General.Common;
using General.Encoding;
using General.Encoding.Object;

namespace GameEngine.Data.Entities {
	public class EntityIO : IObjectIO<MapEntity> {
		public EntityIO(IBinaryIO stream, IRegionEntityFactory factory, bool ScrollAffected) {
			this._stream = stream;
			this.factory = factory;
			this.ScrollAffected = ScrollAffected;
		}
		

		IBinaryIO _stream;
		IRegionEntityFactory factory;
		public bool ScrollAffected;

		public void Write(MapEntity e) {
			BinaryOutput stream = _stream as BinaryOutput;
			EntityType type = EntityType.None;
			if (e is BuildingEntity) {
				type = EntityType.Building;
			}
			// todo: add rest of Entities here
			stream.Write((byte)type);
			e.Encode(stream);
		}

		public MapEntity Read() {
			MapEntity result = null;
			BinaryInput stream = _stream as BinaryInput;
			EntityType type = (EntityType)stream.ReadByte();

			if (type == EntityType.Building) {
				result = new BuildingEntity(factory, ScrollAffected);
			}

			IEncodable encodable = result as IEncodable;

			if (encodable != null) {
				encodable.Decode(stream);
			}

			return result;
		}
	}
}

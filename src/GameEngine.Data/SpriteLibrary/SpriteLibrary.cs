using General.Common;
using General.Encoding;

namespace GameEngine.Data.SpriteLibrary {
	public class SpriteLibrary : SpriteLibraryDirectory {
		public void Clear() {
			this.Directories.Clear();
			this.Sprites.Clear();
		}

		public SpriteLibrary() {
			this.Deletable = false;
			this.Unchangeable = true;
		}

		public override void Encode(BinaryOutput stream) {
			stream.Write(Directories.Count);
			Directories.ForEach(d => d.Encode(stream));

			stream.Write(Sprites.Count);
			Sprites.ForEach(s => s.Encode(stream));
		}

		public override IEncodable Decode(BinaryInput stream) {
			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				SpriteLibraryDirectory obj = stream.ReadObject<SpriteLibraryDirectory>();
				obj.Parent = this;
				this.Directories.Add(obj);
			}

			c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				SpriteLibrarySprite obj = stream.ReadObject<SpriteLibrarySprite>();
				obj.Parent = this;
				this.Sprites.Add(obj);
			}

			return this;
		}
	}
}
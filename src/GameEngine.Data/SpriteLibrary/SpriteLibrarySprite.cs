using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.SpriteLibrary {
	public class SpriteLibrarySprite : ISpriteLibraryNode, IEncodable {
		public Texture2D Texture;

		public SpriteLibrarySprite() {
		}

		public SpriteLibrarySprite(ISpriteLibraryNode construct) : this() {
			this.Parent = construct.Parent;
			this.Name = construct.Name;
			this.Unchangeable = construct.Unchangeable;
			this.Deletable = construct.Deletable;
		}

		public string Name { get; set; }
		public bool Deletable { get; set; }
		public bool Unchangeable { get; set; }
		public bool Root { get; private set; }

		public SpriteLibraryDirectory Parent { get; set; }

		public void MapParent() {
			/*Stack<SpriteLibraryDirectory> stack = new Stack<SpriteLibraryDirectory>();

			foreach (SpriteLibraryDirectory pair in SpriteLibrary.Instance.Directories.Reverse<SpriteLibraryDirectory>())
				stack.Push(pair);

			SpriteLibraryDirectory lastNode = null;

			while (stack.Count > 0) {
				SpriteLibraryDirectory current = stack.Pop();
				foreach (SpriteLibraryDirectory pair in current.Directories.Reverse<SpriteLibraryDirectory>()) {
					if (Equals(pair)) {
						Parent = pair;
						return;
					}
					stack.Push(pair);
				}
			}*/
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(Name);
			stream.Write(Unchangeable);
			stream.Write(Deletable);
			stream.Write(Texture);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Name = stream.ReadString();
			this.Unchangeable = stream.ReadBoolean();
			this.Deletable = stream.ReadBoolean();
			this.Texture = stream.ReadTexture();
			return this;
		}
	}
}
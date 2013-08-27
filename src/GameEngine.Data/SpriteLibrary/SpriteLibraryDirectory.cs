using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.SpriteLibrary {
	public class SpriteLibraryDirectory : ISpriteLibraryNode, IEncodable {
		public List<SpriteLibraryDirectory> Directories;
		public List<SpriteLibrarySprite> Sprites;

		public List<ISpriteLibraryNode> All {
			get {
				List<ISpriteLibraryNode> result = new List<ISpriteLibraryNode>();
				result.AddRange(Directories.ToArray());
				result.AddRange(Sprites.ToArray());
				return result;
			}
		}

		public SpriteLibraryDirectory() {
			this.Directories = new List<SpriteLibraryDirectory>();
			this.Sprites = new List<SpriteLibrarySprite>();
		}

		public SpriteLibraryDirectory(ISpriteLibraryNode construct) : this() {
			this.Name = construct.Name;
			this.Parent = construct.Parent;
			this.Unchangeable = construct.Unchangeable;
			this.Deletable = construct.Deletable;
		}

		public string Name { get; set; }
		public bool Deletable { get; set; }
		public bool Unchangeable { get; set; }
		public SpriteLibraryDirectory Parent { get; set; }

		public bool Root {
			get { return !this.Deletable && Parent == null; }
		}

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

		public void Add(ISpriteLibraryNode node) {
			if (node is SpriteLibrarySprite) Sprites.Add(node as SpriteLibrarySprite);
			else if (node is SpriteLibraryDirectory) Directories.Add(node as SpriteLibraryDirectory);
		}

		public void Remove(ISpriteLibraryNode node) {
			if (node is SpriteLibrarySprite) Sprites.Remove(node as SpriteLibrarySprite);
			else if (node is SpriteLibraryDirectory) Directories.Remove(node as SpriteLibraryDirectory);
		}

		public bool TokenValid(string name) {
			return !Regex.IsMatch(name, "[^A-Za-z0-9^.:/$()<>$#_]");
		}

		public bool TokenFree(string name) {
			return All.All(node => node.Name != name);
		}

		public bool HasTexture(string name) {
			return Sprites.Any(t => t.Name == name);
		}

		public bool HasDirectory(string name) {
			return Directories.Any(d => d.Name == name);
		}

		public Texture2D GetSprite(string path) {
			if (path.Contains(".")) {
				//strip next section from string
				string[] sections = path.Split('.');
				string strippedpath = "";
				for (int i = 1; i < sections.Length; i++) {
					strippedpath += sections[i];
					if (i != sections.Length - 1) strippedpath += ".";
				}
				return GetDirectory(sections[0]).GetSprite(strippedpath);
			}
			return Sprites.Where(sprite => sprite.Name == path).Select(sprite => sprite.Texture).FirstOrDefault();
		}

		public SpriteLibraryDirectory GetDirectory(string name) {
			return Directories.FirstOrDefault(d => d.Name == name);
		}

		public virtual void Encode(BinaryOutput stream) {
			stream.Write(this.Name);
			stream.Write(this.Deletable);

			stream.Write(Directories.Count);
			foreach (SpriteLibraryDirectory pair in Directories) {
				stream.Write(pair);
			}

			stream.Write(Sprites.Count);
			foreach (SpriteLibrarySprite pair in Sprites) {
				stream.Write(pair);
			}
		}

		public virtual IEncodable Decode(BinaryInput stream) {
			this.Name = stream.ReadString();
			this.Deletable = stream.ReadBoolean();

			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				SpriteLibraryDirectory child = stream.ReadObject<SpriteLibraryDirectory>();
				child.Parent = this;
				Directories.Add(child);
			}

			c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				SpriteLibrarySprite child = stream.ReadObject<SpriteLibrarySprite>();
				child.Parent = this;
				Sprites.Add(child);
			}

			return this;
		}
	}
}
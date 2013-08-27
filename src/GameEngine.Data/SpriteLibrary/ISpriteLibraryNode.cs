namespace GameEngine.Data.SpriteLibrary {
	public interface ISpriteLibraryNode {
		string Name { get; 
			set; 
		}
		bool Root { get; }
		bool Deletable { get; set; }
		bool Unchangeable { get; set; }
		SpriteLibraryDirectory Parent { get; set; }
		void MapParent();
	}
}
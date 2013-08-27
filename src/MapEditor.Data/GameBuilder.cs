using System;
using System.IO;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Tiles;
using General.Common;
using General.Encoding;

namespace MapEditor.Data {
	public class GameBuilder {
		public static GameBuilder Instance {
			get { return Static<GameBuilder>.Value; }
		}

		public void BuildGame(Project project, string loc) {
			FileStream stream = File.OpenWrite(loc);
			BinaryOutput output = new BinaryOutput(stream);


			output.Write(project.World.TilesetContainer.Count);
			foreach (Tileset t in project.World.TilesetContainer) {
				output.Write(t);
			}

			output.Write(project.World.EntityContainer.All().Count);
			foreach (EntityTemplate e in project.World.EntityContainer.All()) {
				output.Write(e);
			}


		}
	}
}
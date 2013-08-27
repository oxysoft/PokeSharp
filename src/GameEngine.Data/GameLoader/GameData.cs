using System.Collections.Generic;
using System.IO;
using GameEngine.Data.Common;
using GameEngine.Data.Player;
using General.Encoding;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.GameLoader {
	public class GameData {
		public RegionData RegionData;
		public List<MapData> MapDatas;
		public List<PlayerData> Saves;

		public GameData() {
			MapDatas = new List<MapData>();
			Saves = new List<PlayerData>();
		}

		public static void DumpGame(World world, string loc) {
			DumpGame(world, File.OpenWrite(loc));
		}

		public static void DumpGame(World world, Stream stream) {
			using (BinaryOutput output = new BinaryOutput(stream)) {
				DumpGame(world, output);
			}
		}

		public static void DumpGame(World world, BinaryOutput output) {
			new RegionData().Encode(output, world);

			output.Write(world.Maps.Count);
			foreach (Map map in world.Maps) {
				new MapData().Encode(output, map);
			}
		}

		public static GameData ReadGame(GraphicsDevice graphicsDevice, string loc) {
			using (BinaryInput input = new BinaryInput(File.OpenRead(loc))) {
				return ReadGame(graphicsDevice, input);
			}
		}

		public static GameData ReadGame(GraphicsDevice graphicsDevice, BinaryInput input) {
			GameData result = new GameData();

			input.GraphicsDevice = graphicsDevice;

			result.RegionData = new RegionData();
			result.RegionData.Decode(input);

			int c = input.ReadInt32();
			for (int i = 0; i < c; i++) {
				MapData data = new MapData();
				data.Decode(input);
				result.MapDatas.Add(data);
			}

			return result;
		}
	}
}
using System;
using System.Collections.Generic;
using GameEngine.Data.Entities.Living.Core;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Tiles.Behaviors {
	public class TileBehavior {
		public static readonly TileBehavior SurfableHop = new TileBehavior(0, "Surfable Hop", "You can surf on this tile and surf onto", "O", new Color(0, 0, 255)).AddTag("surf");
		public static readonly TileBehavior Surfable = new TileBehavior(1, "Surfable", "You can surf on this tile but cannot surf onto", "1", new Color(0, 128, 255)).AddTag("surf");
		public static readonly TileBehavior Ice = new TileBehavior(2, "Ice", "It will be slippery", "", new Color(0, 255, 255)).AddTag("ice");
		public static readonly TileBehavior SpinUp = new TileBehavior(3, "Spin up", "Sends you spinning until a solid object is hit", "", new Color(128, 128, 255)).AddTag("spin").AddData("direction", Facing.Up);
		public static readonly TileBehavior SpinDown = new TileBehavior(4, "Spin down", "Sends you spinning until a solid object is hit", "", new Color(255, 255, 0)).AddTag("spin").AddData("direction", Facing.Down);
		public static readonly TileBehavior SpinLeft = new TileBehavior(5, "Spin left", "Sends you spinning until a solid object is hit", "", new Color(255, 255, 0)).AddTag("spin").AddData("direction", Facing.Left);
		public static readonly TileBehavior SpinRight = new TileBehavior(6, "Spin right", "Sends you spinning until a solid object is hit", "", new Color(255, 255, 0)).AddTag("spin").AddData("direction", Facing.Right);
		public static readonly TileBehavior JumpUp = new TileBehavior(7, "Ledge up", "A small ledge you can jump down but not above", "", new Color(255, 190, 0)).AddTag("jump").AddData("direction", Facing.Up);
		public static readonly TileBehavior JumpDown = new TileBehavior(8, "Ledge down", "A small ledge you can jump down but not above", "", new Color(255, 190, 0)).AddTag("jump").AddData("direction", Facing.Down);
		public static readonly TileBehavior JumpLeft = new TileBehavior(9, "Ledge left", "A small ledge you can jump down but not above", "", new Color(255, 190, 0)).AddTag("jump").AddData("direction", Facing.Left);
		public static readonly TileBehavior JumpRight = new TileBehavior(10, "Ledge right", "A small ledge you can jump down but not above", "", new Color(255, 190, 0)).AddTag("jump").AddData("direction", Facing.Right);
		public static readonly TileBehavior CrossingHeight = new TileBehavior(11, "Crossing of different height", "Height changes", "OO", new Color(0, 0, 255));
		public static readonly TileBehavior Height0 = new TileBehavior(12, "Height 0", "Sets the height to 0", "5", new Color(255, 255, 0)).AddData("height", 0);
		public static readonly TileBehavior Height1 = new TileBehavior(13, "Height 1", "Sets the height to 1", "8", new Color(128, 128, 0)).AddData("height", 1);
		public static readonly TileBehavior Height2 = new TileBehavior(14, "Height 2", "Sets the height to 2", "C", new Color(128, 0, 128)).AddData("height", 2);
		public static readonly TileBehavior Height3 = new TileBehavior(15, "Height 3", "Sets the height to 3", "14", new Color(74, 162, 45)).AddData("height", 3);
		public static readonly TileBehavior Height4 = new TileBehavior(16, "Height 4", "Sets the height to 4", "18", new Color(0, 83, 0)).AddData("height", 4);
		public static readonly TileBehavior Height5 = new TileBehavior(17, "Height 5", "Sets the height to 5", "1C", new Color(21, 106, 93)).AddData("height", 5);
		public static readonly TileBehavior Height6 = new TileBehavior(18, "Height 6", "Sets the height to 6", "20", new Color(112, 53, 192)).AddData("height", 6);
		public static readonly TileBehavior Height7 = new TileBehavior(19, "Height 7", "Sets the height to 7", "24", new Color(78, 112, 33)).AddData("height", 7);
		public static readonly TileBehavior Height8 = new TileBehavior(20, "Height 8", "Sets the height to 8", "28", new Color(180, 222, 33)).AddData("height", 8);
		public static readonly TileBehavior Height9 = new TileBehavior(21, "Height 9", "Sets the height to 9", "2C", new Color(30, 172, 104)).AddData("height", 9);
		public static readonly TileBehavior Obstacle = new TileBehavior(22, "Obstacle", "An obstacle, it cannot be passed", "", new Color(255, 0, 0)).AddData("heightObstacle", 0);
		//public static readonly TileBehavior ObstacleHeight1 = new TileBehavior(23, "", "", Color.Black).AddData("heightObstacle", 1);
		//public static readonly TileBehavior ObstacleHeight2 = new TileBehavior(24, "", "", Color.Black).AddData("heightObstacle", 2);
		//public static readonly TileBehavior ObstacleHeight3 = new TileBehavior(25, "", "", Color.Black).AddData("heightObstacle", 3);
		//public static readonly TileBehavior ObstacleHeight4 = new TileBehavior(26, "", "", Color.Black).AddData("heightObstacle", 4);
		//public static readonly TileBehavior ObstacleHeight5 = new TileBehavior(27, "", "", Color.Black).AddData("heightObstacle", 5);
		//public static readonly TileBehavior ObstacleHeight6 = new TileBehavior(28, "", "", Color.Black).AddData("heightObstacle", 6);
		//public static readonly TileBehavior ObstacleHeight7 = new TileBehavior(29, "", "", Color.Black).AddData("heightObstacle", 7);
		//public static readonly TileBehavior ObstacleHeight8 = new TileBehavior(30, "", "", Color.Black).AddData("heightObstacle", 8);
		//public static readonly TileBehavior ObstacleHeight9 = new TileBehavior(31, "", "", Color.Black).AddData("heightObstacle", 9);

		public readonly byte Id;
		public readonly string Name, Identifier, Description;
		public readonly Color Color;
		public readonly List<Tuple<string, object>> Datas;
		public readonly List<string> Tags;

		public TileBehavior(byte id, string name, string description, string identifier, Color color) {
			this.Id = id;
			this.Name = name;
			this.Identifier = identifier;
			this.Description = description;
			this.Color = color;
			Datas = new List<Tuple<string, object>>();
			Tags = new List<string>();
		}

		public TileBehavior AddData(string name, object item) {
			Datas.Add(new Tuple<string, object>(name, item));
			return this;
		}

		public TileBehavior AddTag(string tag) {
			Tags.Add(tag);
			return this;
		}

		private static TileBehaviorCollection values;

		public static TileBehaviorCollection Values {
			get {
				if (values == null) {
					values = new TileBehaviorCollection();
					values.Add(SurfableHop);
					values.Add(Surfable);
					values.Add(Ice);
					values.Add(SpinUp);
					values.Add(SpinDown);
					values.Add(SpinLeft);
					values.Add(SpinRight);
					values.Add(JumpUp);
					values.Add(JumpDown);
					values.Add(JumpLeft);
					values.Add(JumpRight);
					values.Add(CrossingHeight);
					values.Add(Height0);
					values.Add(Height1);
					values.Add(Height2);
					values.Add(Height3);
					values.Add(Height4);
					values.Add(Height5);
					values.Add(Height6);
					values.Add(Height7);
					values.Add(Height8);
					values.Add(Height9);
					values.Add(Obstacle);
				}
				return values;
			}
		}

		public static TileBehavior GetBehavior(byte id) {
			return Values[id];
		}
	}
}
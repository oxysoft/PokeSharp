using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Common;
using GameEngine.Data.Entities.Living.Core;
using GameEngine.Data.Entities.Types;
using General.Common;
using General.Encoding;
using General.Utilities;

namespace GameEngine.Data.Entities.Living.Npcs {
	public class MovementBehavior : IEncodable {
		public List<Movement> Movements;
		public NPCEntity Entity;
		public MovementPattern Pattern;
		public MovementFrequency Frequency;
		public MovementSpeed Speed;
		public short Count, CurrentIndex;
		public bool Inverted;

		public MovementBehavior() {
			this.Movements = new List<Movement>();
		}

		public MovementBehavior(NPCEntity entity) : this() {
			this.Entity = entity;
		}

		public void GeneateMovementList() {
			Movements.Clear();

			switch (Pattern) {
				case MovementPattern.UpDown:
					for (int i = 0; i < Count; i++)
						Movements.Add(new Movement(!Inverted ? Facing.Up : Facing.Down, Speed));
					for (int i = 0; i < Count; i++)
						Movements.Add(new Movement(!Inverted ? Facing.Down : Facing.Up, Speed));
					break;
				case MovementPattern.LeftRight:
					for (int i = 0; i < Count; i++)
						Movements.Add(new Movement(!Inverted ? Facing.Left : Facing.Right, Speed));
					for (int i = 0; i < Count; i++)
						Movements.Add(new Movement(!Inverted ? Facing.Right : Facing.Left, Speed));
					break;
			}
		}

		public Movement NextMovement() {
			if (CurrentIndex > Movements.Count) CurrentIndex = 0;
			switch (Pattern) {
				case MovementPattern.Random:
					Facing n = Facing.Right;
					int r = Randomizer.Next(4);
					if (r == 0) n = Facing.Down;
					else if (r == 1) n = Facing.Up;
					else if (r == 2) n = Facing.Left;
					else if (r == 3) n = Facing.Right;
					return new Movement(n, MovementSpeed.Walking);
				case MovementPattern.LogicalRandom:
					Facing nn = Facing.Right;
					int rr = Randomizer.Next(4);
					if (rr == 0) nn = Facing.Down;
					else if (rr == 1) nn = Facing.Up;
					else if (rr == 2) nn = Facing.Left;
					else if (rr == 3) nn = Facing.Right;
					return Randomizer.NextBool() ? new Movement(nn, MovementSpeed.Walking) : new Movement(nn, MovementSpeed.Zero);
				case MovementPattern.UpDown:
					return Movements[CurrentIndex++];
				case MovementPattern.LeftRight:
					return Movements[CurrentIndex++];
			}
			return null;
		}

		public float NextMovementTime() {
			return this.Frequency.NextMovement() / 100f;
		}

		public void Encode(BinaryOutput stream) {
			stream.Write((byte) Pattern);
			stream.Write((byte) Speed);
			stream.Write(Count);
			stream.Write(CurrentIndex);
			stream.Write(Inverted);
			stream.Write(Movements.Count);
			Movements.ForEach(m => m.Encode(stream));
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Pattern = (MovementPattern) stream.ReadByte();
			this.Speed = (MovementSpeed) stream.ReadByte();
			this.Count = stream.ReadInt16();
			this.CurrentIndex = stream.ReadInt16();
			this.Inverted = stream.ReadBoolean();
			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				Movements.Add(stream.ReadObject<Movement>());
			}
			return this;
		}
	}
}
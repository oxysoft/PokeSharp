using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Entities.Living;
using GameEngine.Data.Entities.Living.Core;
using GameEngine.Data.Entities.Living.Npcs;
using GameEngine.Data.Entities.World;

namespace GameEngine.Data.Entities.Types {
	public class NPCEntity : LivingEntity {
		public MovementBehavior MovementBehavior;
		private float elapsed, nextMovement;

		public NPCEntity(IRegionEntityFactory factory, bool cameraAffected) : base(factory, cameraAffected) {
		}

		private int movements = 0;

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			elapsed += (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (elapsed > nextMovement && this.Movable) {
				Movement move = MovementBehavior.NextMovement();
				if (move.Speed == MovementSpeed.Zero) this.Face(move.Facing);
				else this.TryMove(move.Facing, move.Speed);

				this.elapsed = 0;
				this.nextMovement = MovementBehavior.NextMovementTime();
				//GameConsole.WriteLine("MOV" + movements++ + ", next time: " + nextMovement);
			}
			base.Update(gameTime);
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			base.Draw(gameTime);
		}

		public override void Encode(General.Encoding.BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(MovementBehavior);
			stream.Write(elapsed);
			stream.Write(nextMovement);
		}

		public override General.Common.IEncodable Decode(General.Encoding.BinaryInput stream) {
			base.Decode(stream);
			this.MovementBehavior = stream.ReadObject<MovementBehavior>();
			this.MovementBehavior.Entity = this;
			this.elapsed = stream.ReadSingle();
			this.nextMovement = stream.ReadSingle();

			return this;
		}
	}
}
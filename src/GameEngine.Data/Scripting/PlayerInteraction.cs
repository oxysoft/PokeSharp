using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Entities.Living.Core;
using GameEngine.Data.Entities.Types;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Scripting {
	public class PlayerInteraction {
		//aint giving no access to every members of PlayerEntity/LivingEntity!
		protected PlayerEntity player;

		public PlayerInteraction(PlayerEntity player) {
			this.player = player;
		}

		public void TryMove(Facing dir, MovementSpeed speed) {
			player.TryMove(dir, speed);
		}

		public void ForceMove(Facing dir, MovementSpeed speed) {
			player.ForceMove(dir, speed);
		}

		public void Face(Facing dir) {
			player.Face(dir);
		}

		public void Lock(float duration) {
			player.Lock(duration);
		}

		public void Lock() {
			player.Lock();
		}

		public void Lock(string uid, float duration) {
			player.Lock(uid, duration);
		}

		public void Lock(string uid) {
			player.Lock(uid);
		}

		public void Release() {
			player.Release();
		}

		public void Release(bool force) {
			player.Release(force);
		}

		public void Release(string uid) {
			player.Release(uid);
		}

		public Vector2 Position {
			get { return player.Position; }
			set { player.Position = value; }
		}

		public Vector2 TilePosition {
			get { return player.TilePosition; }
		}

		public bool Visible {
			get { return player.Visible; }
		}

		public bool Locked {
			get { return player.Locked; }
		}

		public bool Movable {
			get { return player.Movable; }
		}

		public bool Turning {
			get { return player.Turning; }
		}

		public Vector2 AbsolutePosition {
			get { return player.AbsolutePosition; }
		}
	}
}

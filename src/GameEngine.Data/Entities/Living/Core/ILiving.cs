using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Data.Entities.Living.Core {
	public interface ILiving {
		void TryMove(Facing dir, MovementSpeed speed); //Apply collision check
		void ForceMove(Facing dir, MovementSpeed speed); //Ignore terrain and stuff
		void Face(Facing dir); //Turn around
		void Lock(float duration);
		void Lock();
		void Release();
		bool CanMove(Facing dir); //Can walk one tile in direction of 'dir' ?
		bool CanMove(Facing dir, int amount); //Can walk 'amount' tile in direction of 'dir' ?
	}
}
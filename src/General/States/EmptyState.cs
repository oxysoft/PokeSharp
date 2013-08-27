using General.Common;
using Microsoft.Xna.Framework;

namespace General.States {
	public class EmptyState : IState {
		#region Singleton
		public static EmptyState Instance {
			get {
				return Static<EmptyState>.Value;
			}
		}
		#endregion

		#region IState Member
		public string Name {
			get {
				return "None";
			}
		}
		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
		}
		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
		}
		public void Draw(GameTime gameTime) {
		}
		public void Update(GameTime gameTime) {
		}
		#endregion
	}
}

using Microsoft.Xna.Framework;

namespace General.States {
	public interface IState {
		string Name {
			get;
		}

		void Enter(IFiniteStateMachine stateMachine, IState oldState);
		void Leave(IFiniteStateMachine stateMachine, IState newState);

		void Draw(GameTime gameTime);
		void Update(GameTime gameTime);
	}
}

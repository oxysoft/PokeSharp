using Microsoft.Xna.Framework;

namespace General.States {
	public class FiniteStateMachine : IFiniteStateMachine {
		#region Constructors

		public virtual string Name {
			get {
				return "FiniteStateMachine";
			}
		}

		public FiniteStateMachine() {
			this.State = EmptyState.Instance;
		}
		#endregion

		#region Properties
		public IState State {
			get;
			private set;
		}
		#endregion

		#region Methods
		public void Update(GameTime gameTime) {
			this.State.Update(gameTime);
		}
		public void Draw(GameTime gameTime) {
			this.State.Draw(gameTime);
		}
		#endregion

		#region IFiniteStateMachine Member
		public void ChangeState(IState state) {
			IState lastState = this.State;
			if (lastState != null) {
				lastState.Leave(this, state);
			}

			this.State = state;
			this.State.Enter(this, lastState);
		}
		#endregion
	}
}

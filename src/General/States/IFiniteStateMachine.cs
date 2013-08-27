namespace General.States {
	public interface IFiniteStateMachine {
		void ChangeState(IState state);
	}
}

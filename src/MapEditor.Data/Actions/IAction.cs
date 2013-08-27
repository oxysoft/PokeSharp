using System;

namespace MapEditor.Data.Actions {
	public interface IAction {

		string Name {
			get;
		}
		DateTime Time {
			get;
			set;
		}

		void Execute();
		void UnExecute();

	}
}

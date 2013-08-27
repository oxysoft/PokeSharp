using System;
using System.Collections.Generic;
using System.Linq;
using General.Common;

namespace MapEditor.Data.Actions {
	public class MultiAction : IAction, IEncodable {

		public List<IAction> Actions;

		private string name = null;

		public virtual string Name {
			get {
				if (name != null) return name;
				return "Multi Action";
			}
		}

		public virtual void Execute() {
			foreach (IAction a in Actions) {
				a.Execute();
			}
		}

		public virtual void UnExecute() {
			foreach (IAction a in Actions.Reverse<IAction>()) {
				a.UnExecute();
			}
		}

		public MultiAction() {
			this.Actions = new List<IAction>();
		}

		public MultiAction(string name) : this() {
			this.name = name;
		}


		public DateTime Time {
			get;
			set;
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(Name);
			stream.Write(Actions.Count);
			ActionIO writer = new ActionIO(stream);
			foreach (IAction i in Actions) {
				writer.Write(i);
			}
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			name = stream.ReadString();
			int c = stream.ReadInt32();
			ActionIO reader = new ActionIO(stream);

			for (int i = 0; i < c; i++) {
				Actions.Add(reader.Read());
			}

			return this;
		}
	}
}

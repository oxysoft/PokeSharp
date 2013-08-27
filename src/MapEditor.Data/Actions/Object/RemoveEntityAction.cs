using System;
using GameEngine.Data.Entities;
using General.Common;

namespace MapEditor.Data.Actions.Object {
	public class RemoveEntityAction : IAction, IEncodable {
		public RemoveEntityAction() {
		}

		public RemoveEntityAction(int index) {
			this.index = index;
		}

		private int index;

		private MapEntity worldEntity;

		public DateTime Date {
			get;
			set;
		}
		
		public string Title {
			get {
				return "Entity Remove";
			}
		}
	
		public void Execute() {
			this.worldEntity = EditorEngine.Instance.CurrentMap.Entities[index];
			EditorEngine.Instance.CurrentMap.Entities.RemoveAt(this.index);
		}

		public void UnExecute() {
			EditorEngine.Instance.CurrentMap.Entities.Insert(this.index, this.worldEntity);
		}

		public string Name {
			get {
				return "Remove Entity";
			}
		}

		public DateTime Time {
			get;
			set;
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(index);
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			index = stream.ReadInt32();
			return this;
		}
	}
}

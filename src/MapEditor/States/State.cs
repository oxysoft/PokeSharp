using MapEditor.Forms;

namespace MapEditor.States {
	public abstract class State {
		#region Properties
		public FrmMainEditor EditorForm {
			get;
			protected set;
		}
		#endregion

		#region Methods
		public virtual void Initialize(FrmMainEditor mainForm) {
			this.EditorForm = mainForm;
		}
		#endregion
	}
}

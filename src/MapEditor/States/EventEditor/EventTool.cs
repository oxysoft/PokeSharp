using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.States.EntityEditor;
using Microsoft.Xna.Framework;

namespace MapEditor.States.EventEditor {
	public class EventTool : State, IState {
		public string Name { get; private set; }

		public static EventTool Instance {
			get { return Static<EventTool>.Value; }
		}

		public override void Initialize(Forms.FrmMainEditor mainForm) {
			base.Initialize(mainForm);
			
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			this.EditorForm.editorcontrol.MouseEnter += onMouseEnter;
			this.EditorForm.editorcontrol.MouseLeave += onMouseLeave;
			this.EditorForm.editorcontrol.MouseDown += onMouseDown;
			this.EditorForm.editorcontrol.MouseUp += onMouseUp;
			this.EditorForm.editorcontrol.MouseDoubleClick += onMouseDoubleClick;
		}
			

		private void onMouseEnter(object sender, EventArgs e) {
		}
		
		private void onMouseLeave(object sender, EventArgs e) {
		}

		private void onMouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				int x = e.X - EditorEngine.Instance.xCamZ;
				int y = e.Y - EditorEngine.Instance.yCamZ;

				x = (int) (x / EditorEngine.Instance.World.Camera.Scale);
				y = (int) (y / EditorEngine.Instance.World.Camera.Scale);

				if (EditorEngine.Instance.CurrentMap.HasEntity(x, y)) {
					EntitySelectionTool.Instance.SelectedEntities.Add(EditorEngine.Instance.CurrentMap.GetEntity(x, y));
					EditorForm.rMenuEntity.Show(EditorForm.editorcontrol.PointToScreen(e.Location));
				}
			}
		}

		private void onMouseDown(object sender, MouseEventArgs e) {
		}
		private void onMouseDoubleClick(object sender, MouseEventArgs e) {
		}


		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}
	}
}
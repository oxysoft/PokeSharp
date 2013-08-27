using General.Common;
using General.States;
using MapEditor.Data;
using Microsoft.Xna.Framework;

namespace MapEditor.States.EntityEditor {
	public class EntitySelectAllTool : State, IState {
		public static EntitySelectAllTool Instance {
			get {
				return Static<EntitySelectAllTool>.Value;
			}
		}

		public string Name {
			get {
				return "Select All";
			}
		}
		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EntitySelectionTool.Instance.SelectedEntities.Clear();
			EntitySelectionTool.Instance.SelectedEntities.AddRange(EditorEngine.Instance.CurrentMap.Entities);
			EntityEditorState.Instance.ToolStates.ChangeState(EntityMoveTool.Instance);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}
	}
}

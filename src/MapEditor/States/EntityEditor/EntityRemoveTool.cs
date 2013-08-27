using GameEngine.Data.Entities;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.Data.Actions.Object;
using Microsoft.Xna.Framework;

namespace MapEditor.States.EntityEditor {
	public class EntityRemoveTool : State, IState {
		
		public static EntityRemoveTool Instance {
			get {
				return Static<EntityRemoveTool>.Value;
			}
		}

		public string Name {
			get {
				return "Remove";
			}
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			EditorForm.b_entityremove.Checked = true;

			MultipleRemoveEntityAction removeAction = new MultipleRemoveEntityAction();

			foreach (MapEntity worldEntity in EntitySelectionTool.Instance.SelectedEntities) {
				RemoveEntityAction action = new RemoveEntityAction(EditorEngine.Instance.CurrentMap.Entities.IndexOf(worldEntity));
				action.Execute();
				removeAction.Actions.Add(action);
			}

			EditorEngine.Instance.GetActionManager().Push(removeAction);
			EntitySelectionTool.Instance.SelectedEntities.Clear();
			stateMachine.ChangeState(oldState);
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			EditorForm.b_entityremove.Checked = false;
		}

		public void Draw(GameTime gameTime) {
		}

		public void Update(GameTime gameTime) {
		}
	}
}

using System;
using System.Collections.Generic;
using System.Timers;
using General.Extensions;

namespace MapEditor.Data.Actions {
	public class ActionManager {

		bool isReplaying = false;
		Stack<IAction> s_undo;
		Stack<IAction> s_redo;

		public ActionManager() {
			this.s_redo = new Stack<IAction>();
			this.s_undo = new Stack<IAction>();
		}

		public bool canUndo {
			get {
				return s_undo.Count > 0 && !isReplaying;
			}
		}

		public bool canRedo {
			get {
				return s_redo.Count > 0 && !isReplaying;
			}
		}

		public int undoCount {
			get {
				return s_undo.Count;
			}
		}

		public int redoCount {
			get {
				return s_redo.Count;
			}
		}

		public List<IAction> Actions {
			get {
				List<IAction> undoList = new List<IAction>();
				List<IAction> redoList = new List<IAction>();
				List<IAction> result = new List<IAction>();

				undoList.AddRange(this.s_undo);
				redoList.AddRange(this.s_redo);

				undoList.Reverse();

				result.AddRange(undoList);
				result.AddRange(redoList);

				return result;
			}
		}

		public event EventHandler Changed;
		public event EventHandler ExecuteUndo;
		public event EventHandler ExecuteRedo;

		public void Execute(IAction action) {
			action.Execute();
			Push(action);
		}

		public void Push(IAction action) {
			s_undo.Push(action);
			s_redo.Clear();
			EditorEngine.Instance.HasEdit = true;
			Changed.SafeInvoke(this, EventArgs.Empty);
		}

		public void Undo() {
			if (canUndo) {
				IAction a = s_undo.Pop();
				a.UnExecute();
				s_redo.Push(a);
				EditorEngine.Instance.HasEdit = true;
				ExecuteUndo.SafeInvoke(this, EventArgs.Empty);
			}
		}

		public void Redo() {
			if (canRedo) {
				IAction a = s_redo.Pop();
				a.Execute();
				s_undo.Push(a);
				EditorEngine.Instance.HasEdit = true;
				ExecuteRedo.SafeInvoke(this, EventArgs.Empty);
			}
		}

		public void ReplayAll() {
			EditorEngine.Instance.HasEdit = true;
			ReplayAll(100);
		}

		public void ReplayAll(int delay) {
			if (!isReplaying) {

				while (s_undo.Count > 0) {
					Undo();
				}

				Timer timer = new Timer(delay);

				timer.Elapsed += new ElapsedEventHandler(delegate(object sender, ElapsedEventArgs e) {
					if (!(s_redo.Count > 0)) {
						timer.Stop();
						isReplaying = false;
					} else {
						IAction a = s_redo.Pop();
						a.Execute();
						s_undo.Push(a);
						ExecuteRedo.SafeInvoke(this, EventArgs.Empty);
					}

				});

				isReplaying = true;
				timer.Start();

			}
		}

		public void Clear() {
			s_undo.Clear();
			s_redo.Clear();
			Changed.Invoke(this, EventArgs.Empty);
		}

		public void Reset() {
			int count = s_undo.Count;
			for (int i = 0; i < count; i++) {
				Undo();
			}
		}


	}
}

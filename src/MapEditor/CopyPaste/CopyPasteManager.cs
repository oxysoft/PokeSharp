using System.IO;
using System.Windows.Forms;
using GameEngine.Data.Entities;
using General.Common;
using General.Encoding;
using MapEditor.Data;
using MapEditor.Data.Actions.Object;
using MapEditor.Forms;
using MapEditor.States.EntityEditor;
using Microsoft.Xna.Framework;

namespace MapEditor.CopyPaste {
	public class CopyPasteManager {

		private FrmMainEditor editorform;
		private bool Initialized = false;

		public static CopyPasteManager Instance {
			get {
				return Static<CopyPasteManager>.Value;
			}
		}

		public void Initialize(FrmMainEditor frm) {
			this.editorform = frm;
			this.Initialized = true;
		}

		public void Copy() {
			if (this.Initialized) {
				if (EditorEngine.Instance.StateMachine.State == EntityEditorState.Instance) {
					//DataObject obj = new DataObject("aeon_entities", null);
					DataFormats.Format f = DataFormats.GetFormat("aeon_entities");
					IDataObject obj = new DataObject();

					MemoryStream stream = new MemoryStream();
					BinaryOutput bin = new BinaryOutput(stream);

					bin.Write(EntitySelectionTool.Instance.SelectedEntities.Count);
					//write Template index and positions, no actual Entities :>
					EntitySelectionTool.Instance.SelectedEntities.ForEach(e => {
						bin.Write(e.TemplateID);
						bin.Write(e.Position.X);
						bin.Write(e.Position.Y);
					});

					obj.SetData(f.Name, false, stream);
					Clipboard.SetDataObject(obj);
				}
			}
		}

		public void Paste() {
			if (this.Initialized) {
				MemoryStream stream = null;
				IDataObject obj = Clipboard.GetDataObject();
				const string format = "aeon_entities";

				if (obj.GetDataPresent(format)) {
					stream = obj.GetData(format) as MemoryStream;
				}

				EntitySelectionTool.Instance.SelectedEntities.Clear();
				BinaryInput bin = new BinaryInput(stream);

				int c = bin.ReadInt32();
				for (int i = 0; i < c; i++) {
					int temp_index = bin.ReadInt32();
					int x = (int)bin.ReadSingle() >> 4;
					int y = (int)bin.ReadSingle() >> 4;

					AddEntityAction act = new AddEntityAction(EditorEngine.Instance.World.EntityContainer.All()[temp_index], new Vector2(x, y));
					EditorEngine.Instance.GetActionManager().Execute(act);

					MapEntity result = act.worldEntity;
					EntitySelectionTool.Instance.SelectedEntities.Add(result);
				}
			}
		}
	}
}

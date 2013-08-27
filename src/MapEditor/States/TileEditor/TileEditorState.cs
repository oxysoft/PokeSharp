using System.Windows.Forms;
using General.Common;
using General.States;
using MapEditor.Data;
using MapEditor.Forms;
using MapEditor.Forms.Form_Selectors;
using Microsoft.Xna.Framework;

namespace MapEditor.States.TileEditor {
	public class TileEditorState : State, IState {
		public TileEditorState() {
			this.ToolStates = new FiniteStateMachine();
			this.LayerStates = new FiniteStateMachine();
		}

		public string Name {
			get { return "TileEditorState"; }
		}

		public FiniteStateMachine ToolStates { get; private set; }

		public FiniteStateMachine LayerStates { get; private set; }

		public int SelectedLayer { get; set; }

		public int SelectedTileset {
			get { return FrmTilesetSelector.Instance.comboBoxEdit1.SelectedIndex; }
			set { FrmTilesetSelector.Instance.comboBoxEdit1.SelectedIndex = value; }
		}

		public Rectangle SelectedRegion {
			get { return FrmTilesetSelector.Instance.control.SelectedRegion; }
			set { FrmTilesetSelector.Instance.control.SelectedRegion = value; }
		}

		public static TileEditorState Instance {
			get { return Static<TileEditorState>.Value; }
		}

		public bool initialized = false;

		public override void Initialize(FrmMainEditor mainForm) {
			if (!initialized) {
				base.Initialize(mainForm);

				PencilTool.Instance.Initialize(mainForm);
				RectangleTool.Instance.Initialize(mainForm);
				BucketTool.Instance.Initialize(mainForm);
				EraserTool.Instance.Initialize(mainForm);
				LogicBrushTool.Instance.Initialize(mainForm);

				/*Once per runtime*/
				EditorForm.editorcontrol.MouseDown += new MouseEventHandler(onMouseDown);
				EditorForm.editorcontrol.MouseMove += new MouseEventHandler(onMouseMove);
				EditorForm.editorcontrol.MouseUp += new MouseEventHandler(onMouseUp);

				initialized = true;
			}
		}

		public void Enter(IFiniteStateMachine stateMachine, IState oldState) {
			//this.EditorForm.barTiles.Visible = true;
			this.EditorForm.lbLayer.Visible = true;
			this.EditorForm.bTiles.Enabled = true;
			this.EditorForm.bTiles.Checked = true;

			this.EditorForm.spinLayer.Visible = true;
			this.EditorForm.b_hand.Visible = true;
			this.EditorForm.b_pencil.Visible = true;
			this.EditorForm.b_eraser.Visible = true;
			this.EditorForm.b_bucket.Visible = true;
			this.EditorForm.b_rectangle.Visible = true;
			this.EditorForm.b_logic.Visible = true;

			if (ToolStates.State == LogicBrushTool.Instance) {
				FrmLogicTileSelector.Instance.TopLevel = false;
				FrmLogicTileSelector.Instance.FormBorderStyle = FormBorderStyle.None;
				FrmLogicTileSelector.Instance.Dock = DockStyle.Fill;
				FrmLogicTileSelector.Instance.Visible = true;
				EditorForm.splitContainer1.Panel1.Controls.Clear();
				EditorForm.splitContainer1.Panel1.Controls.Add(FrmLogicTileSelector.Instance);
			} else {
				FrmTilesetSelector.Instance.TopLevel = false;
				FrmTilesetSelector.Instance.FormBorderStyle = FormBorderStyle.None;
				FrmTilesetSelector.Instance.Dock = DockStyle.Fill;
				FrmTilesetSelector.Instance.Visible = true;
				EditorForm.splitContainer1.Panel1.Controls.Clear();
				EditorForm.splitContainer1.Panel1.Controls.Add(FrmTilesetSelector.Instance);
			}

			this.ToolStates.ChangeState(PencilTool.Instance);
			this.EditorForm.Focus();
		}

		/*Global Tools*/

		private void onMouseDown(object obj, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				this.mx = e.X;
				this.my = e.Y;
			}
		}

		private int mx, my;

		private void onMouseMove(object obj, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				int x = e.X;
				int y = e.Y;

				//int xc = (int)((mx - e.X) / EditorEngine.Instance.Zoom);
				//int yc = (int)((my - e.Y) / EditorEngine.Instance.Zoom);

				int xc = (mx - e.X);
				int yc = (my - e.Y);

				EditorEngine.Instance.MoveView(-xc, -yc);

				this.mx = x;
				this.my = y;
			}
		}

		private void onMouseUp(object obj, MouseEventArgs e) {
		}

		public void Leave(IFiniteStateMachine stateMachine, IState newState) {
			this.EditorForm.bTiles.Checked = false;
			this.EditorForm.lbLayer.Visible = false;
			this.EditorForm.spinLayer.Visible = false;
			this.EditorForm.b_hand.Visible = false;
			this.EditorForm.b_pencil.Visible = false;
			this.EditorForm.b_eraser.Visible = false;
			this.EditorForm.b_bucket.Visible = false;
			this.EditorForm.b_rectangle.Visible = false;
			this.EditorForm.b_logic.Visible = false;
		
			EditorForm.splitContainer1.Panel1.Controls.Clear();
			this.ToolStates.State.Leave(stateMachine, newState);
		}

		public void Draw(GameTime gameTime) {
			this.ToolStates.Draw(gameTime);
		}

		public void Update(GameTime gameTime) {
			this.ToolStates.Update(gameTime);
		}
	}
}
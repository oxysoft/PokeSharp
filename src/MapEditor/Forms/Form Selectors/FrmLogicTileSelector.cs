using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using General.Common;
using MapEditor.Data;
using MapEditor.Data.TileLogicNew;
using MapEditor.States.TileEditor;
using MapEditor.States.TileEditor.Logic;

namespace MapEditor.Forms.Form_Selectors {
	public partial class FrmLogicTileSelector : Form {
		public FrmLogicTileSelector() {
			InitializeComponent();
		}

		public static FrmLogicTileSelector Instance {
			get { return Static<FrmLogicTileSelector>.Value; }
		}

		public int CurrentLogicIndex {
			get { return logicViewerSelectorControl1.SelectedLogicIndex; }
		}

		private void FrmLogicTileSelector_Load(object sender, EventArgs e) {
			logicViewerSelectorControl1.Initialize(vScrollBar1);

			this.logicViewerSelectorControl1.SelectedLogic += onSelectedLogic;
			Options.Instance.LogicCorrectSameType = true;
			size = 1;
			lbSize.Text = "" + size;
		}

		private void onSelectedLogic(object sender, EventArgs e) {
			int l_index = logicViewerSelectorControl1.SelectedLogicIndex;
			if (l_index > -1 && l_index < TileLogicManager.Instance.logics.Count) {
				lbTileName.Text = TileLogicManager.Instance.logics[l_index].name;
			}
		}

		public int size = 0;

		private void btnReloadAll_Click(object sender, EventArgs e) {
			TileLogicManager.Instance.ReloadAllLogics();
		}
		
		private void btnPencil_Click(object sender, EventArgs e) {
			LogicBrushTool.Instance.ChangeState(LogicPencilTool.Instance);
		}

		private void btnRectangle_Click(object sender, EventArgs e) {
			LogicBrushTool.Instance.ChangeState(LogicRectangleTool.Instance);
		}

		private void btnBucket_Click(object sender, EventArgs e) {
			LogicBrushTool.Instance.ChangeState(LogicBucketTool.Instance);
		}

		private void btnPath_Click(object sender, EventArgs e) {
			LogicBrushTool.Instance.ChangeState(LogicPathTool.Instance);
		}

		private void btnSizeDecrease_Click(object sender, EventArgs e) {
			if (size - 1 > 0) size--;
			lbSize.Text = "" + size;
		}

		private void btnSizeIncrease_Click(object sender, EventArgs e) {
			if (size + 1 < 17) size++;
			lbSize.Text = "" + size;
		}

		private void btnUseSameTypeLogic_Click(object sender, EventArgs e) {
		}

		private void btnCorrectSameTypeTile_Click(object sender, EventArgs e) {
			Options.Instance.LogicCorrectSameType = btnCorrectSameTypeTile.Checked;
		}

		private void btnCorrectOtherTypeTile_Click(object sender, EventArgs e) {
			Options.Instance.LogicCorrectOtherType = btnCorrectOtherTypeTile.Checked;
		}

	}
}
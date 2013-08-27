using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MapEditor.UI.FastColoredTextbox
{
    /// <summary>
    /// Dictionary of shortcuts for FCTB
    /// </summary>
    public class HotkeysMapping : SortedDictionary<Keys, FCTBAction>
    {
        public virtual void InitDefault()
        {
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G] = FCTBAction.GoToDialog;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F] = FCTBAction.FindDialog;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F] = FCTBAction.FindChar;
            this[System.Windows.Forms.Keys.F3] = FCTBAction.FindNext;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H] = FCTBAction.ReplaceDialog;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C] = FCTBAction.Copy;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.C] = FCTBAction.CommentSelected;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X] = FCTBAction.Cut;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V] = FCTBAction.Paste;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A] = FCTBAction.SelectAll;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z] = FCTBAction.Undo;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R] = FCTBAction.Redo;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U] = FCTBAction.UpperCase;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U] = FCTBAction.LowerCase;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus] = FCTBAction.NavigateBackward;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.OemMinus] = FCTBAction.NavigateForward;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B] = FCTBAction.BookmarkLine;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.B] = FCTBAction.UnbookmarkLine;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N] = FCTBAction.GoNextBookmark;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.N] = FCTBAction.GoPrevBookmark;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Back] = FCTBAction.Undo;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Back] = FCTBAction.ClearWordLeft;
            this[System.Windows.Forms.Keys.Insert] = FCTBAction.ReplaceMode;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert] = FCTBAction.Copy;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Insert] = FCTBAction.Paste;
            this[System.Windows.Forms.Keys.Delete] = FCTBAction.DeleteCharRight;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete] = FCTBAction.ClearWordRight;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete] = FCTBAction.Cut;
            this[System.Windows.Forms.Keys.Left] = FCTBAction.GoLeft;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Left] = FCTBAction.GoLeftWithSelection;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left] = FCTBAction.GoWordLeft;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Left] = FCTBAction.GoWordLeftWithSelection;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Left] = FCTBAction.GoLeft_ColumnSelectionMode;
            this[System.Windows.Forms.Keys.Right] = FCTBAction.GoRight;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Right] = FCTBAction.GoRightWithSelection;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right] = FCTBAction.GoWordRight;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Right] = FCTBAction.GoWordRightWithSelection;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Right] = FCTBAction.GoRight_ColumnSelectionMode;
            this[System.Windows.Forms.Keys.Up] = FCTBAction.GoUp;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Up] = FCTBAction.GoUpWithSelection;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Up] = FCTBAction.GoUp_ColumnSelectionMode;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up] = FCTBAction.MoveSelectedLinesUp;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up] = FCTBAction.ScrollUp;
            this[System.Windows.Forms.Keys.Down] = FCTBAction.GoDown;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Down] = FCTBAction.GoDownWithSelection;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Down] = FCTBAction.GoDown_ColumnSelectionMode;
            this[System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down] = FCTBAction.MoveSelectedLinesDown;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down] = FCTBAction.ScrollDown;
            this[System.Windows.Forms.Keys.PageUp] = FCTBAction.GoPageUp;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.PageUp] = FCTBAction.GoPageUpWithSelection;
            this[System.Windows.Forms.Keys.PageDown] = FCTBAction.GoPageDown;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.PageDown] = FCTBAction.GoPageDownWithSelection;
            this[System.Windows.Forms.Keys.Home] = FCTBAction.GoHome;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Home] = FCTBAction.GoHomeWithSelection;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Home] = FCTBAction.GoFirstLine;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Home] = FCTBAction.GoFirstLineWithSelection;
            this[System.Windows.Forms.Keys.End] = FCTBAction.GoEnd;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.End] = FCTBAction.GoEndWithSelection;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End] = FCTBAction.GoLastLine;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.End] = FCTBAction.GoLastLineWithSelection;
            this[System.Windows.Forms.Keys.Escape] = FCTBAction.ClearHints;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M] = FCTBAction.MacroRecord;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E] = FCTBAction.MacroExecute;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space] = FCTBAction.AutocompleteMenu;
            this[System.Windows.Forms.Keys.Tab] = FCTBAction.IndentIncrease;
            this[System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Tab] = FCTBAction.IndentDecrease;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Subtract] = FCTBAction.ZoomOut;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Add] = FCTBAction.ZoomIn;
            this[System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0] = FCTBAction.ZoomNormal;
        }

        public override string ToString()
        {
            var cult = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            StringBuilder sb = new StringBuilder();
            var kc = new KeysConverter();
            foreach (var pair in this)
            {
                sb.AppendFormat("{0}={1}, ", kc.ConvertToString(pair.Key), pair.Value);
            }

            if (sb.Length > 1)
                sb.Remove(sb.Length - 2, 2);
            Thread.CurrentThread.CurrentUICulture = cult;

            return sb.ToString();
        }

        public static HotkeysMapping Parse(string s)
        {
            var result = new HotkeysMapping();
            result.Clear();
            var cult = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            var kc = new KeysConverter();
            
            foreach (var p in s.Split(','))
            {
                var pp = p.Split('=');
                var k = (Keys)kc.ConvertFromString(pp[0].Trim());
                var a = (FCTBAction)Enum.Parse(typeof(FCTBAction), pp[1].Trim());
                result[k] = a;
            }

            Thread.CurrentThread.CurrentUICulture = cult;

            return result;
        }
    }

    /// <summary>
    /// Actions for shortcuts
    /// </summary>
    public enum FCTBAction
    {
        None,
        AutocompleteMenu,
        BookmarkLine,
        ClearHints,
        ClearWordLeft,
        ClearWordRight,
        CommentSelected,
        Copy,
        Cut,
        DeleteCharRight,
        FindChar,
        FindDialog,
        FindNext,
        GoDown,
        GoDownWithSelection,
        GoDown_ColumnSelectionMode,
        GoEnd,
        GoEndWithSelection,
        GoFirstLine,
        GoFirstLineWithSelection,
        GoHome,
        GoHomeWithSelection,
        GoLastLine,
        GoLastLineWithSelection,
        GoLeft,
        GoLeftWithSelection,
        GoLeft_ColumnSelectionMode,
        GoPageDown,
        GoPageDownWithSelection,
        GoPageUp,
        GoPageUpWithSelection,
        GoRight,
        GoRightWithSelection,
        GoRight_ColumnSelectionMode,
        GoToDialog,
        GoNextBookmark,
        GoPrevBookmark,
        GoUp,
        GoUpWithSelection,
        GoUp_ColumnSelectionMode,
        GoWordLeft,
        GoWordLeftWithSelection,
        GoWordRight,
        GoWordRightWithSelection,
        IndentIncrease,
        IndentDecrease,
        LowerCase,
        MacroExecute,
        MacroRecord,
        MoveSelectedLinesDown,
        MoveSelectedLinesUp,
        NavigateBackward,
        NavigateForward,
        Paste,
        Redo,
        ReplaceDialog,
        ReplaceMode,
        ScrollDown,
        ScrollUp,
        SelectAll,
        UnbookmarkLine,
        Undo,
        UpperCase,
        ZoomIn,
        ZoomNormal,
        ZoomOut,
        CustomAction1,
        CustomAction2,
        CustomAction3,
        CustomAction4,
        CustomAction5,
        CustomAction6,
        CustomAction7,
        CustomAction8,
        CustomAction9,
        CustomAction10,
        CustomAction11,
        CustomAction12,
        CustomAction13,
        CustomAction14,
        CustomAction15,
        CustomAction16,
        CustomAction17,
        CustomAction18,
        CustomAction19,
        CustomAction20
    }

    internal class HotkeysEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((provider != null) && (((IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService))) != null))
            {
                var form = new HotkeysEditorForm(HotkeysMapping.Parse(value as string));

                if (form.ShowDialog() == DialogResult.OK)
                    value = form.GetHotkeys().ToString();
            }
            return value;
        }
    }
}

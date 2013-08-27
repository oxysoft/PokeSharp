using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace General.Extensions
{
    public static class GameExtensions
    {
        #region Methods
        public static Form GetWinForm(this Game game)
        {
            IntPtr handle = game.Window.Handle;
            Form result = (Form)Form.FromHandle(handle);

            return result;
        }
        #endregion
    }
}

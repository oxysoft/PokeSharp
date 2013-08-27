using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using General.Common;

namespace General.Extensions
{
    public static class EventHandlerExtensions
    {
        #region Methods
        public static void SafeInvoke(this EventHandler handler, object sender, EventArgs args)
        {
            if (handler != null)
            {
                ThreadInvoker.Invoke(() => handler.Invoke(sender, args));
            }
        }
        public static void SafeInvoke<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            if (handler != null)
            {
                ThreadInvoker.Invoke(() => handler.Invoke(sender, args));
            }
        }
        #endregion
    }
}

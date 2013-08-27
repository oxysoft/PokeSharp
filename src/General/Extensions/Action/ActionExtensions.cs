using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace General.Extensions
{
    /*public static class ActionExtensions
    {
        #region Methods
        public static CancellationTokenSource Parallel(this Action action)
        {
            CancellationTokenSource source = new CancellationTokenSource();

            Task task = new Task(action, source.Token);
            task.Start();

            return source;
        }
        #endregion
    }*/
}

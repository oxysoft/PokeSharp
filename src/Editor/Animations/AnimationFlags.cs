using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Graphics.Animations {
	[Flags]
	public enum AnimationFlags {
		None = 0x00,
        Loopable = 0x01,
        Resettable = 0x02
	}
}

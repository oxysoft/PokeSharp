using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Encoding;

namespace General.Graphics.Animations {
	public class Animation : IEncodable {
		#region Constructors

		public Animation() {
			this.Indices = new List<int>();
			this.TimePerFrame = 0.01f;
		}

		public Animation(float timePerFrame)
			: this() {
			this.TimePerFrame = timePerFrame;
		}

		public Animation(float timePerFrame, int[] indices, AnimationFlags flags)
			: this() {
			this.TimePerFrame = timePerFrame;
			this.Flags = flags;

			this.Indices.AddRange(indices);
		}

		#endregion

		#region Fields

		#endregion

		#region Properties

		public string Name { get; set; }

		public float TimePerFrame { get; set; }
		public AnimationFlags Flags { get; set; }

		public bool Loopable {
			get { return (this.Flags & AnimationFlags.Loopable) == AnimationFlags.Loopable; }
		}

		public bool Resettable {
			get { return (this.Flags & AnimationFlags.Resettable) == AnimationFlags.Resettable; }
		}

		public List<int> Indices { get; private set; }

		#endregion

		public void Encode(BinaryOutput stream) {
			stream.Write(this.Name);
			stream.Write(this.TimePerFrame);
			stream.Write((byte) this.Flags);

			stream.Write(this.Indices.Count);
			foreach (int value in this.Indices) {
				stream.Write(value);
			}
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Name = stream.ReadString();
			this.TimePerFrame = stream.ReadSingle();
			this.Flags = (AnimationFlags) stream.ReadByte();

			int count = stream.ReadInt32();
			for (int i = 0; i < count; i++) {
				this.Indices.Add(stream.ReadInt32());
			}

			return this;
		}
	}
}
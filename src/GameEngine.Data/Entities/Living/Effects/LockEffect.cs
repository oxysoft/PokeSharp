using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Entities.Living.Effects {
	public class LockEffect : IEffect {
		public LockEffect() {
		}
		
		public LockEffect(string uid, float duration) {
			this.Uid = uid;
			this.Duration = duration;
		}

		public string Name {
			get { return "Lock"; }
		}

		public string Uid { get; set; }
		public float Duration { get; set; }
		public bool Alive { get; set; }
		public float Elapsed;

		public void Update(GameTime gameTime) {
			Elapsed += (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (Elapsed > Duration) {
				Alive = false;
			}
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(Uid);
			stream.Write(Elapsed);
			stream.Write(Duration);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Uid = stream.ReadString();
			this.Elapsed = stream.ReadSingle();
			this.Duration = stream.ReadSingle();
			return this;
		}
	}
}
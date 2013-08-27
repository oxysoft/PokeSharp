using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Entities.Living.Effects {
	public interface IEffect : IEncodable {
		string Name { get; }
		string Uid { get; set; }
		float Duration { get; set; }
		bool Alive { get; set; }

		void Update(GameTime gameTime);
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Entities.Types;
using General.Common;
using General.Encoding;
using General.Script;
using Jint;
using Jint.Debugger;
using Jint.Native;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Noesis.Javascript;

namespace GameEngine.Data.Scripting.UserInterface {
	public class UI {
		public string Name;
		private bool valid;
		private SpriteBatch spriteBatch;
		public PlayerEntity PlayerEntity;
		public UITemplate Template;
		public SharpScript engine;

		public UI(UITemplate template, SpriteBatch spriteBatch, PlayerEntity playerEntity) {
			this.Template = template;
			this.spriteBatch = spriteBatch;
			this.PlayerEntity = playerEntity;
		}

		public void Load() {
			engine = new SharpScript();
			engine.CompileCode(Template.Code, new InterfaceInteraction(this, spriteBatch, this.PlayerEntity));

			engine.Invoke("Initialize");
		}

		public void Invalidate() {
			this.valid = false;
		}

		public void Draw(GameTime gameTime) {
			spriteBatch.Begin();
			engine.Invoke("Draw", gameTime);
			spriteBatch.End();
		}
	}
}
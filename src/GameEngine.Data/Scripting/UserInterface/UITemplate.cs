using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameEngine.Data.Entities.Types;
using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Scripting.UserInterface {
	public class UITemplate : IScriptContainer, IEncodable {
		public string Name;
		public string Code { get; set; }

		public string StrippedCode {
			get {
				Regex r = new Regex("\\r\\n");
				string stripped = r.Replace(Code, "");
				return stripped;
			}
		}

		public UITemplate() {
		}

		public string DefaultCode() {
			StringBuilder sb = new StringBuilder();
			string rn = Environment.NewLine;

			sb.Append("//Reminder: You cannot have any empty function. See how I've inserted 'return null;' in each functions?").Append(rn);
			sb.Append("//          Had this been not there, the script would not function properly and would give an error on runtime.").Append(rn);
			sb.Append("//          If the function consists only of comments, that also counts as empty. If it has more than one statement,").Append(rn);
			sb.Append("//          Then it is not empty and 'return null;' is not required.").Append(rn + rn);

			sb.Append("function Initialize() {").Append(rn);
			sb.Append("\treturn null;").Append(rn);
			sb.Append("}").Append(rn + rn);

			sb.Append("function OnKeyDown() {").Append(rn);
			sb.Append("\treturn null;").Append(rn);
			sb.Append("}").Append(rn + rn);

			sb.Append("function Draw(gameTime) {").Append(rn);
			sb.Append("\treturn null;").Append(rn);
			sb.Append("}");
			return sb.ToString();
		}

		public UI CreateUI(SpriteBatch spriteBatch, PlayerEntity playerEntity) {
			UI res = new UI(this, spriteBatch, playerEntity);
			res.Template = this;
			return res;
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(Name);
			stream.Write(Code);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Name = stream.ReadString();
			this.Code = stream.ReadString();
			return this;
		}
	}
}
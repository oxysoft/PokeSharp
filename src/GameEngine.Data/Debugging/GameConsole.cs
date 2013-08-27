using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace GameEngine.Data.Debugging {
	public class GameConsole {
		private World world;
		public List<ICommand> Commands;
		public List<LineInfo> Strings;
		public LineInfo Input;
		public bool Visible, AutoScroll;
		public float Opacity;


		public GameConsole() {
		}

		public void Update(GameTime gameTime) {
			KeyboardState state = Keyboard.GetState();
			if (state.IsKeyDown(Keys.OemTilde)) {
				this.Show();
			}
			if (state.IsKeyDown(Keys.Escape) && Visible) {
				this.Hide();
			}

			if (this.Visible) {
				foreach (Keys k in state.GetPressedKeys()) {
					Input.Write(k.ToString());
				}
			}
		}

		public void Draw(GameTime gameTime) {
		}

		public void WriteLine(string message) {
			Write("\n" + message);
		}

		public void Write(string message) {
			string[] splitted = message.Split(new string[] {"\n"}, StringSplitOptions.None);
			Queue<string> queue = new Queue<string>(splitted);
			string first = queue.Dequeue();
			while (queue.Count > 0) {
				Strings.Add(new LineInfo(queue.Dequeue()));
			}
		}

		public void Show() {
			this.Visible = true;
		}

		public void Hide() {
			this.Visible = false;
		}
	}

	public class LogType {
		public static readonly LogType Information = new LogType(0, "Information", Color.LightGray);
		private static readonly LogType InfoTile = new LogType("TileInfo", Information);
		private static readonly LogType InfoBattle = new LogType("BattleInfo", Information);
		private static readonly LogType InfoCheat = new LogType("CheatInfo", Information);
		private static readonly LogType InfoEntity = new LogType("EntityInfo", Information);
		private static readonly LogType InfoTextRenderer = new LogType("InfoTextRenderer", Information);

		public static readonly LogType Normal = new LogType(1, "Normal", Color.White);
		public static readonly LogType Warning = new LogType(2, "Warning", Color.Yellow);
		public static readonly LogType Error = new LogType(3, "Error", Color.Crimson);

		public readonly int ErrorLevel;
		public readonly string Name;
		public readonly Color TextColor;
		public readonly List<LogType> Subs;
		public bool Enabled;

		private LogType(string name, LogType parent) {
			this.Name = name;
			this.TextColor = parent.TextColor;
			this.ErrorLevel = parent.ErrorLevel;
			parent.Subs.Add(this);
		}

		private LogType(int errorLevel, string name, Color textColor, params LogType[] subs) {
			this.ErrorLevel = errorLevel;
			this.Name = name;
			this.TextColor = textColor;
			Subs = new List<LogType>(subs);
		}

		public LogType Sub(string name) {
			Subs.Add(new LogType(name, this));
			return this;
		}
	}
}
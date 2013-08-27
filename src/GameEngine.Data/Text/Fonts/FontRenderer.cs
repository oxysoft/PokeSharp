using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using General.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Text.Fonts {
	public class FontRenderer {
		public List<Font> Fonts = new List<Font>();

		public const string FONT_TABLE = @"0123456789" +
		                                 "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
		                                 "abcdefghijklmnopqrstuvwxyz" +
		                                 "ÀÁÂÄÇÈÉÊËÌÍÎÏÑÒÓÔÖ×ÙÚÛÜß" +
		                                 "àáâäǻçèéêëìíîïñòóôö÷ùúûüŒœᵃᵒᵉᶠʳ" +
		                                 "₱¡¿!?,.…`/''“”„«»()♂♀+-*#=&~:;" +
		                                 "♠♣♥⧫★☉Ο☐▲◊@♪%☀πππ☺πππ↑↓ππ" +
		                                 "πππππππππ"; /*All of these are garbage characters we can't represent, they are Pokemon exclusive*/

		public static FontRenderer Instance {
			get { return Static<FontRenderer>.Value; }
		}

		public void Initialize(GraphicsDevice graphicsDevice) {
			CharOffsetTable.Initialize();

			string[] splitted = Application.ExecutablePath.Split('\\');
			string loc2 = "";
			for (int i = 0; i < splitted.Length - 1; i++) {
				loc2 += splitted[i] + '\\';
			}
			string loc = loc2 + @"\Graphics\-Fonts\";

			int fontIndex = 0;
			foreach (DirectoryInfo dir in new DirectoryInfo(loc).GetDirectories()) {
				Font font = new Font("simple"); //dir.Name.Split('&')[1]);
				int cCount = 0;
				int mCount = dir.GetFiles().Length;
				for (int i = 0; i < mCount; i++) {
					string floc = dir.FullName + @"\" + i + ".png";
					Texture2D texture = Texture2D.FromStream(graphicsDevice, File.OpenRead(floc));
					if (texture != null) {
						char c = FONT_TABLE[cCount];
						CharInfo Character = new CharInfo(fontIndex, c, texture);
						font.Characters.Add(Character);
					}
					cCount++;
				}
				Fonts.Add(font);
				fontIndex++;
			}

			//CreateFromExisting(graphicsDevice, loc + @"1\", 0, new List<Tuple<int, int>>(new Tuple<int, int>[] {new Tuple<int, int>(0x101821, 0x52525A), new Tuple<int, int>(0xA5A5A5, 0xA5A5AD)}));
			//CreateFromExisting(graphicsDevice, loc + @"1\", 0, new Color(0x10, 0x18, 0x21), new Color(0x52, 0x52, 0x5A), new Color(0xA5, 0xA5, 0xA5), new Color(0xA5, 0xA5, 0xAD));
		}

		public void ReInitialize(GraphicsDevice graphicsDevice) {
			Fonts.Clear();
			Initialize(graphicsDevice);
		}

		public void CreateFromExisting(GraphicsDevice graphicsDevice, string path, int font, Color from1, Color to1, Color from2, Color to2) {
			Font Font = Fonts[font];
			int index = 0;
			foreach (CharInfo Char in Font.Characters) {
				Texture2D texture = Char.Texture;

				if (texture == null) continue;

				Color[] pixels = new Color[texture.Width * texture.Height];
				texture.GetData<Color>(pixels);

				for (int i = 0; i < pixels.Length; i++) {
					Color col = pixels[i];

					if (col == from1)
						pixels[i] = to1;
					if (col == from2)
						pixels[i] = to2;
				}

				Texture2D result = new Texture2D(graphicsDevice, texture.Width, texture.Height);
				result.SetData<Color>(pixels);

				result.SaveAsPng(File.OpenWrite(path + index + ".png"), result.Width, result.Height);
				index++;
			}
		}

		public CharInfo GetCharacter(char c, int font) {
			try {
				int charindex = FONT_TABLE.IndexOf(c);

				if (charindex < 0 || charindex > Fonts[font].Characters.Count) return null;

				return Fonts[font].Characters[charindex];
			} catch (ArgumentOutOfRangeException exc) {
				return null;
			}
		}

		public int Width(string s, int font) {
			int delta = 0;
			foreach (CharInfo Character in s.Select(c => GetCharacter(c, font))) {
				if (Character == null) {
					delta += 4;
					continue;
				} else delta += Character.Width;
			}
			return delta;
		}

		public void Draw(SpriteBatch spriteBatch, string s, int font, int x, int y, float opacity = 1f, float scale = 1f) {
			int deltaWidth = 0;
			Matrix matrix = Matrix.CreateScale(scale);
			foreach (CharInfo Character in s.Select(c => GetCharacter(c, font))) {
				if (Character == null) {
					deltaWidth += 4;
					continue;
				}
				//Texture Width and Height should both be equal to Width and Height alone from the CharInfo object but we rather be on the safe side
				spriteBatch.Draw(Character.Texture, new Rectangle(x + deltaWidth + Character.OffX, y - Character.Texture.Height + Character.OffY, Character.Texture.Width, Character.Texture.Height), Color.White * opacity);
				deltaWidth += Character.Texture.Width;
			}
		}

		public void DrawCentered(SpriteBatch spriteBatch, string s, int font, int y, float opacity = 1f) {
			Draw(spriteBatch, s, font, GameEngine.WIDTH / 2 - Width(s, font) / 2, y, opacity);
		}
	}
}
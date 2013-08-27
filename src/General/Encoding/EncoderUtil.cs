using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using Microsoft.Xna.Framework.Graphics;

namespace General.Encoding {
	public class EncoderUtil {
		public static void Encode(string fileName, IEncodable value) {
			FileStream stream = File.Open(fileName, FileMode.Create);
			EncoderUtil.Encode(stream, value);

			stream.Close();
		}
		public static void Encode(Stream stream, IEncodable value) {
			BinaryOutput output = new BinaryOutput(stream);
			value.Encode(output);
		}
		public static void Encode(BinaryOutput output, IEncodable value) {
			value.Encode(output);
		}
		public static T Decode<T>(Stream stream) where T : IEncodable, new() {
			BinaryInput input = new BinaryInput(stream);

			IEncodable result = new T();
			result.Decode(input);

			return (T)result;
		}
		public static T Decode<T>(string fileName) where T : IEncodable, new() {
			using (FileStream stream = File.Open(fileName, FileMode.Open)) {
				return EncoderUtil.Decode<T>(stream);
			}
		}
		public static T Decode<T>(BinaryInput input) where T : IEncodable, new() {
			IEncodable result = new T();
			result.Decode(input);

			return (T)result;
		}
		public static T Decode<T>(Stream stream, GraphicsDevice graphicsDevice) where T : IEncodable, new() {
			BinaryInput input = new BinaryInput(stream, graphicsDevice);

			IEncodable result = new T();
			result.Decode(input);

			return (T)result;
		}
		public static T Decode<T>(string fileName, GraphicsDevice graphicsDevice) where T : IEncodable, new() {
			using (FileStream stream = File.Open(fileName, FileMode.Open)) {
				return EncoderUtil.Decode<T>(stream, graphicsDevice);
			}
		}
	}
}

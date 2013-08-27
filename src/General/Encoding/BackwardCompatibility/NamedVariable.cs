using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;

namespace General.Encoding.BackwardCompatibility {
	public class NamedVariable : IEncodable {
		private String name;

		public NamedVariable() {
		}

		public NamedVariable(string name) {
			this.name = name;
		}

		public virtual void Encode(BinaryOutput stream) {
			stream.Write(name);
		}

		public virtual IEncodable Decode(BinaryInput stream) {
			name = stream.ReadString();

			return this;
		}
	}

	//Bool
	public class NamedBoolean : NamedVariable {
		private Boolean value;

		public NamedBoolean(string name, Boolean value)
			: base(name) {
			this.value = value;
		}

		public NamedBoolean() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadBoolean();

			return this;
		}
	}

	//Unsigned Byte
	public class NamedByte : NamedVariable {
		private byte value;

		public NamedByte(string name, byte value) : base(name) {
			this.value = value;
		}

		public NamedByte() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadByte();

			return this;
		}
	}

	//Character
	public class NamedChar : NamedVariable {
		private Char value;

		public NamedChar(string name, Char value)
			: base(name) {
			this.value = value;
		}

		public NamedChar() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadChar();

			return this;
		}
	}

	//Decimal
	public class NamedDecimal : NamedVariable {
		private Decimal value;

		public NamedDecimal(string name, Decimal value) : base(name) {
			this.value = value;
		}

		public NamedDecimal() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadDecimal();

			return this;
		}
	}

	//Double
	public class NamedDouble : NamedVariable {
		private Double value;

		public NamedDouble(string name, Double value) : base(name) {
			this.value = value;
		}

		public NamedDouble() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadDouble();

			return this;
		}
	}

	//Short
	public class NamedInt16 : NamedVariable {
		private Int16 value;

		public NamedInt16(string name, Int16 value) : base(name) {
			this.value = value;
		}

		public NamedInt16() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadInt16();

			return this;
		}
	}

	//32-bit Signed Integer
	public class NamedInt32 : NamedVariable {
		private Int32 value;

		public NamedInt32(string name, Int32 value) : base(name) {
			this.value = value;
		}

		public NamedInt32() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadInt32();

			return this;
		}
	}

	//64-bit Signed Long
	public class NamedInt64 : NamedVariable {
		private Int64 value;

		public NamedInt64(string name, Int32 value)
			: base(name) {
			this.value = value;
		}

		public NamedInt64() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadInt64();

			return this;
		}
	}

	//Signed Byte
	public class NamedSByte : NamedVariable {
		private SByte value;

		public NamedSByte(string name, SByte value)
			: base(name) {
			this.value = value;
		}

		public NamedSByte() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadSByte();

			return this;
		}
	}

	//Float
	public class NamedSingle : NamedVariable {
		private Single value;

		public NamedSingle(string name, Single value)
			: base(name) {
			this.value = value;
		}

		public NamedSingle() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadSingle();

			return this;
		}
	}

	//String
	public class NamedString : NamedVariable {
		private String value;

		public NamedString(string name, String value)
			: base(name) {
			this.value = value;
		}

		public NamedString() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadString();

			return this;
		}
	}

	//Unsigned 16-bit Short
	public class NamedUInt16 : NamedVariable {
		private UInt16 value;

		public NamedUInt16(string name, UInt16 value)
			: base(name) {
			this.value = value;
		}

		public NamedUInt16() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadUInt16();

			return this;
		}
	}

	//Unsigned 32-bit Integer
	public class NamedUInt32 : NamedVariable {
		private UInt32 value;

		public NamedUInt32(string name, UInt32 value)
			: base(name) {
			this.value = value;
		}

		public NamedUInt32() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadUInt32();

			return this;
		}
	}

	//Unsigned 64-bit Long
	public class NamedUInt64 : NamedVariable {
		private UInt64 value;

		public NamedUInt64(string name, UInt64 value)
			: base(name) {
			this.value = value;
		}

		public NamedUInt64() {
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadUInt64();

			return this;
		}
	}

	public class NamedEncodable<T> : NamedVariable where T : IEncodable, new() {
		private IEncodable value;

		public NamedEncodable(string name, IEncodable value) : base(name) {
			this.value = value;
		}

		public override void Encode(BinaryOutput stream) {
			base.Encode(stream);
			stream.Write(value);
		}

		public override IEncodable Decode(BinaryInput stream) {
			base.Decode(stream);
			value = stream.ReadObject<T>();
			return this;
		}
	}
}
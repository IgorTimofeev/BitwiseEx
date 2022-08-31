using System.Text;

namespace BitwiseEx.Protocol;

public static class EncodingExtensions {
	#region Int

	public static void Encode(this byte[] destination, ref int index, in int value, in byte valueByteCount) {
		// Negative value
		if (value < 0) {
			// Sign bit
			destination[index++] = (byte) ((valueByteCount - 1) << 1 | 0b0000_0001);
			destination.Write(ref index, -value, in valueByteCount);
		}
		// Positive
		else {
			destination[index++] = (byte) ((valueByteCount - 1) << 1);
			destination.Write(ref index, in value, in valueByteCount);
		}
	}

	public static void Encode(this byte[] destination, ref int index, in int value) {
		destination.Encode(ref index, in value, value.GetByteCount());
	}

	public static int DecodeInt(this byte[] source, ref int index) {
		var prefix = source[index++];

		var isNegative = (prefix & 1) == 1;
		prefix >>= 1;
		
		var result = source.ReadInt(ref index, (byte) (prefix + 1));

		if (isNegative)
			result = -result;

		return result;
	}

	#endregion

	#region UInt

	public static void Encode(this byte[] destination, ref int index, in uint value, in byte valueByteCount) {
		destination[index++] = (byte) (valueByteCount - 1);
		destination.Write(ref index, in value, in valueByteCount);
	}

	public static void Encode(this byte[] destination, ref int index, in uint value) {
		destination.Encode(ref index, in value, value.GetByteCount());
	}

	public static uint DecodeUInt(this byte[] source, ref int index) {
		return source.ReadUInt(ref index, (byte) (source[index++] + 1));
	}

	#endregion

	#region Byte[]

	public static void Encode(this byte[] destination, ref int index, byte[] value, in byte valueLengthByteCount) {
		// Writing body length
		destination.Encode(ref index, (uint) value.Length, in valueLengthByteCount);

		// Writing body
		Array.Copy(value, 0, destination, index, value.Length);

		index += value.Length;
	}

	public static void Encode(this byte[] destination, ref int index, byte[] value) {
		destination.Encode(ref index, value, value.Length.GetByteCount());
	}

	public static byte[] DecodeByteArray(this byte[] source, ref int index, in int length) {
		byte[] result = new byte[length];

		Array.Copy(source, index, result, 0, length);

		index += length;

		return result;
	}

	public static byte[] DecodeByteArray(this byte[] source, ref int index) {
		return source.DecodeByteArray(ref index, (int) source.DecodeUInt(ref index));
	}

	#endregion

	#region String

	public static void Encode(this byte[] destination, ref int index, in string value, in byte valueLengthByteCount, Encoding encoding) {
		destination.Encode(ref index, encoding.GetBytes(value), in valueLengthByteCount);
	}

	public static void Encode(this byte[] destination, ref int index, in string value, Encoding encoding) {
		destination.Encode(ref index, in value, value.Length.GetByteCount(), encoding);
	}

	public static string DecodeString(this byte[] source, ref int index, in int length, Encoding encoding) {
		return encoding.GetString(source.DecodeByteArray(ref index, in length));
	}

	public static string DecodeString(this byte[] source, ref int index, Encoding encoding) {
		return source.DecodeString(ref index, source.DecodeInt(ref index), encoding);
	}

	#endregion
}
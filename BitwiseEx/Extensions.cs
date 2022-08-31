namespace BitwiseEx;

public static class BitwiseExtensions {
	public static byte GetByteCount(this int value) {
		if (value >= 0) {
			if (value <= 0xFF) {
				return 1;
			}
			else if (value <= 0xFFFF) {
				return 2;
			}
			else if (value <= 0xFFFFFF) {
				return 3;
			}

			return 4;
		}
		else {
			if (value >= -0xFF) {
				return 1;
			}
			else if (value >= -0xFFFF) {
				return 2;
			}
			else if (value >= -0xFFFFFF) {
				return 3;
			}

			return 4;
		}
	}

	public static byte GetByteCount(this uint value) {
		if (value <= 0xFF) {
			return 1;
		}
		else if (value <= 0xFFFF) {
			return 2;
		}
		else if (value <= 0xFFFFFF) {
			return 3;
		}
		
		return 4;
	}

	public static byte GetByteCount(this long value) {
		if (value >= 0) {
			if (value <= 0xFF) {
				return 1;
			}
			else if (value <= 0xFFFF) {
				return 2;
			}
			else if (value <= 0xFFFFFF) {
				return 3;
			}
			else if (value <= 0xFFFFFFFF) {
				return 4;
			}
			else if (value <= 0xFFFFFFFFFF) {
				return 5;
			}
			else if (value <= 0xFFFFFFFFFFFF) {
				return 6;
			}
			else if (value <= 0xFFFFFFFFFFFFFF) {
				return 7;
			}

			return 8;
		}
		else {
			if (value >= -0xFF) {
				return 1;
			}
			else if (value >= -0xFFFF) {
				return 2;
			}
			else if (value >= -0xFFFFFF) {
				return 3;
			}
			else if (value >= -0xFFFFFFFF) {
				return 4;
			}
			else if (value >= -0xFFFFFFFFFF) {
				return 5;
			}
			else if (value >= -0xFFFFFFFFFFFF) {
				return 6;
			}
			else if (value >= -0xFFFFFFFFFFFFFF) {
				return 7;
			}

			return 8;
		}
	}

	#region ToByteArray

	public static byte[] ToByteArray(this int value, in byte byteCount = 4) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	public static byte[] ToByteArray(this uint value, in byte byteCount = 8) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	public static byte[] ToByteArray(this long value, in byte byteCount = 8) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	public static byte[] ToByteArray(this ulong value, in byte byteCount = 16) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	#endregion

	#region Writing

	public static void Write(this byte[] destination, ref int index, in int value, in byte valueByteCount = 4) {
		for (int i = (valueByteCount - 1) * 8; i >= 0; i -= 8)
			destination[index++] = (byte) (value >> i & 0xFF);
	}

	public static void Write(this byte[] destination, ref int index, in uint value, in byte valueByteCount = 8) {
		for (int i = (valueByteCount - 1) * 8; i >= 0; i -= 8)
			destination[index++] = (byte) (value >> i & 0xFF);
	}

	public static void Write(this byte[] destination, ref int index, in long value, in byte valueByteCount = 8) {
		for (int i = (valueByteCount - 1) * 8; i >= 0; i -= 8)
			destination[index++] = (byte) (value >> i & 0xFF);
	}

	public static void Write(this byte[] destination, ref int index, in ulong value, in byte valueByteCount = 8) {
		for (int i = (valueByteCount - 1) * 8; i >= 0; i -= 8)
			destination[index++] = (byte) (value >> i & 0xFF);
	}

	#endregion

	#region Reading

	public static int ReadInt(this byte[] source, ref int index, in byte valueByteCount = 4, bool littleEndian = false) {
		int result = 0;

		if (littleEndian) {
			index += valueByteCount - 1;

			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index--];

			index += valueByteCount + 1;
		}
		else {
			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index++];
		}

		return result;
	}

	public static uint ReadUInt(this byte[] source, ref int index, in byte valueByteCount = 8, bool littleEndian = false) {
		uint result = 0;

		if (littleEndian) {
			index += valueByteCount - 1;

			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index--];

			index += valueByteCount + 1;
		}
		else {
			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index++];
		}

		return result;
	}

	public static long ReadLong(this byte[] source, ref int index, in byte valueByteCount = 8, bool littleEndian = false) {
		long result = 0;

		if (littleEndian) {
			index += valueByteCount - 1;

			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index--];

			index += valueByteCount + 1;
		}
		else {
			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index++];
		}

		return result;
	}

	public static ulong ReadULong(this byte[] source, ref int index, in byte valueByteCount = 16, bool littleEndian = false) {
		ulong result = 0;

		if (littleEndian) {
			index += valueByteCount - 1;

			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index--];

			index += valueByteCount + 1;
		}
		else {
			for (int i = 0; i < valueByteCount; i++)
				result = result << 8 | source[index++];
		}

		return result;
	}

	#endregion
}
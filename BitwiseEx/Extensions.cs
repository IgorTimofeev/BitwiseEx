namespace BitwiseEx;

public static class BitwiseExtensions {
	/// <returns> Minimum number of bytes required to represent an <see cref="int"/> <paramref name="value"/> unambiguously </returns>
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

	/// <returns> Minimum number of bytes required to represent an <see cref="uint"/> <paramref name="value"/> unambiguously </returns>
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

	/// <returns> Minimum number of bytes required to represent an long <paramref name="value"/> unambiguously </returns>
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

	/// <returns> Minimum number of bytes required to represent an <see cref="ulong"/> <paramref name="value"/> unambiguously </returns>
	public static byte GetByteCount(this ulong value) {
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

	#region ToByteArray

	/// <summary>
	/// Transforms an <see cref="int"/> <paramref name="value"/> to byte array with the desired <paramref name="byteCount"/>
	/// </summary>
	/// <param name="value">Original number</param>
	/// <param name="byteCount">Count of bytes number should be split to</param>
	/// <returns>Byte array representing a <paramref name="value"/></returns>
	public static byte[] ToByteArray(this int value, in byte byteCount = 4) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	/// <summary>
	/// Transforms an <see cref="uint"/> <paramref name="value"/> to byte array with the desired <paramref name="byteCount"/>
	/// </summary>
	/// <param name="value">Original number</param>
	/// <param name="byteCount">Count of bytes number should be split to</param>
	/// <returns>Byte array representing a <paramref name="value"/></returns>
	public static byte[] ToByteArray(this uint value, in byte byteCount = 8) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	/// <summary>
	/// Transforms an long <paramref name="value"/> to byte array with the desired <paramref name="byteCount"/>
	/// </summary>
	/// <param name="value">Original number</param>
	/// <param name="byteCount">Count of bytes number should be split to</param>
	/// <returns>Byte array representing a <paramref name="value"/></returns>
	public static byte[] ToByteArray(this long value, in byte byteCount = 8) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	/// <summary>
	/// Transforms an <see cref="ulong"/> <paramref name="value"/> to byte array with the desired <paramref name="byteCount"/>
	/// </summary>
	/// <param name="value">Original number</param>
	/// <param name="byteCount">Count of bytes number should be split to</param>
	/// <returns>Byte array representing a <paramref name="value"/></returns>
	public static byte[] ToByteArray(this ulong value, in byte byteCount = 16) {
		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	#endregion

	#region Writing

	/// <summary>
	/// Writes an <paramref name="byteCount"/> bytes of <paramref name="value"/> to <paramref name="destination"/> array
	/// starting from <paramref name="index"/> in <see href="https://en.wikipedia.org/wiki/Endianness">big-endian system</see>
	/// </summary>
	/// <param name="destination">Desination array where <paramref name="value"/> should be written to</param>
	/// <param name="index">Starting index of <paramref name="destination"/> array to write <paramref name="value"/></param>
	/// <param name="value">A number that should be written to <paramref name="destination"/> array</param>
	/// <param name="byteCount">Number of bytes that representing <paramref name="value"/> in range [1; 4]</param>
	public static void Write(this byte[] destination, ref int index, in int value, in byte byteCount = 4) {
		for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
			destination[index++] = (byte) (value >> i & 0xFF);
	}

	/// <summary>
	/// <inheritdoc cref="Write(byte[], ref int, in int, in byte)"/>
	/// </summary>
	/// <param name="destination"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="index"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="value"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="byteCount">Number of bytes that representing <paramref name="value"/> in range [1; 8]</param>
	public static void Write(this byte[] destination, ref int index, in uint value, in byte byteCount = 8) {
		for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
			destination[index++] = (byte) (value >> i & 0xFF);
	}

	/// <summary>
	/// <inheritdoc cref="Write(byte[], ref int, in int, in byte)"/>
	/// </summary>
	/// <param name="destination"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="index"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="value"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="byteCount">Number of bytes that representing <paramref name="value"/> in range [1; 8]</param>
	public static void Write(this byte[] destination, ref int index, in long value, in byte byteCount = 8) {
		for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
			destination[index++] = (byte) (value >> i & 0xFF);
	}

	/// <summary>
	/// <inheritdoc cref="Write(byte[], ref int, in int, in byte)"/>
	/// </summary>
	/// <param name="destination"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="index"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="value"><inheritdoc cref="Write(byte[], ref int, in int, in byte)"/></param>
	/// <param name="byteCount">Number of bytes that representing <paramref name="value"/> in range [1; 8]</param>
	public static void Write(this byte[] destination, ref int index, in ulong value, in byte byteCount = 8) {
		for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
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
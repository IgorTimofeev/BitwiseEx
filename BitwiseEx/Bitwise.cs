namespace BitwiseEx;

public static class BitwiseExtensions {
	/// <returns> Minimum number of bytes required to represent an <paramref name="value"/> unambiguously </returns>
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

	/// <inheritdoc cref="GetByteCount(int)"/>
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

	/// <inheritdoc cref="GetByteCount(int)"/>
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

	/// <inheritdoc cref="GetByteCount(int)"/>
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

	static void AssertToByteArrayByteCountRange(in byte byteCount, byte maximum) {
		if (byteCount < 0 || byteCount > maximum)
			throw new ArgumentException($"Expected byteCount value in range [0; {maximum}], but {byteCount} wash given");
	}

	/// <summary>
	/// Converts the <paramref name="value"/> to byte array with the desired <paramref name="byteCount"/>
	/// </summary>
	/// <param name="value"> Original number </param>
	/// <param name="byteCount"> Count of bytes in range [0; 4] <paramref name="value"/> should be converted to </param>
	/// <returns> Byte array representing the <paramref name="value"/> </returns>
	/// <exception cref="ArgumentException"> Thrown if <paramref name="byteCount"/> is out of allowed range </exception>
	public static byte[] ToByteArray(this int value, in byte byteCount = 4) {
		AssertToByteArrayByteCountRange(in byteCount, 4);

		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	/// <summary> <inheritdoc cref="ToByteArray(int, in byte)"/> </summary>
	/// <param name="value"> <inheritdoc cref="ToByteArray(int, in byte)" path="/param[@name='value']"/> </param>
	/// <param name="byteCount"> Count of bytes in range [0; 8] <paramref name="value"/> should be converted to </param>
	/// <returns> <inheritdoc cref="ToByteArray(int, in byte)"/> </returns>
	/// <exception cref="ArgumentException"> <inheritdoc cref="ToByteArray(int, in byte)"/> </exception>
	public static byte[] ToByteArray(this uint value, in byte byteCount = 8) {
		AssertToByteArrayByteCountRange(in byteCount, 8);

		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	/// <summary> <inheritdoc cref="ToByteArray(int, in byte)"/> </summary>
	/// <param name="value"> <inheritdoc cref="ToByteArray(int, in byte)" path="/param[@name='value']"/> </param>
	/// <param name="byteCount"> <inheritdoc cref="ToByteArray(uint, in byte)" path="/param[@name='byteCount']"/> </param>
	/// <returns> <inheritdoc cref="ToByteArray(int, in byte)"/> </returns>
	/// <exception cref="ArgumentException"> <inheritdoc cref="ToByteArray(int, in byte)"/> </exception>
	public static byte[] ToByteArray(this long value, in byte byteCount = 8) {
		AssertToByteArrayByteCountRange(in byteCount, 8);

		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	/// <summary> <inheritdoc cref="ToByteArray(int, in byte)"/> </summary>
	/// <param name="value"> <inheritdoc cref="ToByteArray(int, in byte)" path="/param[@name='value']"/> </param>
	/// <param name="byteCount"> Count of bytes in range [0; 16] <paramref name="value"/> should be converted to </param>
	/// <returns> <inheritdoc cref="ToByteArray(int, in byte)"/> </returns>
	/// <exception cref="ArgumentException"> <inheritdoc cref="ToByteArray(int, in byte)"/> </exception>
	public static byte[] ToByteArray(this ulong value, in byte byteCount = 16) {
		AssertToByteArrayByteCountRange(in byteCount, 16);

		byte[] result = new byte[byteCount];
		int index = 0;

		result.Write(ref index, in value, in byteCount);

		return result;
	}

	#endregion

	#region Writing

	static void AssertWrite(in byte byteCount, byte byteCountMaximum) {
		if (byteCount < 0 || byteCount > byteCountMaximum)
			throw new ArgumentException($"Expected byteCount value in range [0; {byteCountMaximum}], but {byteCount} wash given");
	}

	/// <summary>
	/// Writes an <paramref name="byteCount"/> bytes of <paramref name="value"/> to <paramref name="destination"/> array starting from <paramref name="index"/>
	/// </summary>
	/// <param name="destination">Desination array where <paramref name="value"/> should be written to </param>
	/// <param name="index"> Starting index of <paramref name="destination"/> array to write <paramref name="value"/> </param>
	/// <param name="value"> A number that should be written to <paramref name="destination"/> array </param>
	/// <param name="byteCount"> Number of bytes that representing <paramref name="value"/> in range [1; 4] </param>
	/// <param name="littleEndian"> The <see href="https://en.wikipedia.org/wiki/Endianness">endianness </see> of <paramref name="value"/> bytes when writing. By default big-endian system is used, and parameter value is <see langword="false"/> </param>
	/// <exception cref="ArgumentException"> Thrown if <paramref name="byteCount"/> is out of allowed range </exception>
	public static void Write(this byte[] destination, ref int index, in int value, in byte byteCount = 4, bool littleEndian = false) {
		AssertWrite(in byteCount, 4);
		
		if (littleEndian) {
			for (int i = 0; i < byteCount * 8; i += 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
		else {
			for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
	}

	/// <summary>
	/// <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"/>
	/// </summary>
	/// <param name="destination"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='destination']"/></param>
	/// <param name="index"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='index']"/></param>
	/// <param name="value"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='value']"/></param>
	/// <param name="byteCount">Number of bytes that representing <paramref name="value"/> in range [1; 8]</param>
	/// <param name="littleEndian"> <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='littleEndian']"/> </param>
	/// <exception cref="ArgumentException"> <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"/> </exception>
	public static void Write(this byte[] destination, ref int index, in uint value, in byte byteCount = 8, bool littleEndian = false) {
		AssertWrite(in byteCount, 8);

		if (littleEndian) {
			for (int i = 0; i < byteCount * 8; i += 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
		else {
			for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
	}

	/// <summary>
	/// <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"/>
	/// </summary>
	/// <param name="destination"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='destination']"/></param>
	/// <param name="index"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='index']"/></param>
	/// <param name="value"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='value']"/></param>
	/// <param name="byteCount">Number of bytes that representing <paramref name="value"/> in range [1; 8]</param>
	/// <param name="littleEndian"> <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"  path="/param[@name='littleEndian']"/> </param>
	/// <exception cref="ArgumentException"> <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"/> </exception>
	public static void Write(this byte[] destination, ref int index, in long value, in byte byteCount = 8, bool littleEndian = false) {
		AssertWrite(in byteCount, 8);

		if (littleEndian) {
			for (int i = 0; i < byteCount * 8; i += 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
		else {
			for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
	}

	/// <summary>
	/// <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"/>
	/// </summary>
	/// <param name="destination"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='destination']"/></param>
	/// <param name="index"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='index']"/></param>
	/// <param name="value"><inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)" path="/param[@name='value']"/></param>
	/// <param name="byteCount">Number of bytes that representing <paramref name="value"/> in range [1; 8]</param>
	/// <param name="littleEndian"> <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"  path="/param[@name='littleEndian']"/> </param>
	/// <exception cref="ArgumentException"> <inheritdoc cref="Write(byte[], ref int, in int, in byte, bool)"/> </exception>
	public static void Write(this byte[] destination, ref int index, in ulong value, in byte byteCount = 8, bool littleEndian = false) {
		AssertWrite(in byteCount, 8);

		if (littleEndian) {
			for (int i = 0; i < byteCount * 8; i += 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
		else {
			for (int i = (byteCount - 1) * 8; i >= 0; i -= 8)
				destination[index++] = (byte) (value >> i & 0xFF);
		}
	}

	#endregion

	#region Reading

	public static int ReadInt(this byte[] source, ref int index, in byte valueByteCount = 4) {
		int result = 0;

		for (int i = 0; i < valueByteCount; i++)
			result = result << 8 | source[index++];

		return result;
	}

	public static uint ReadUInt(this byte[] source, ref int index, in byte valueByteCount = 8) {
		uint result = 0;

		for (int i = 0; i < valueByteCount; i++)
			result = result << 8 | source[index++];

		return result;
	}

	public static long ReadLong(this byte[] source, ref int index, in byte valueByteCount = 8) {
		long result = 0;

		for (int i = 0; i < valueByteCount; i++)
			result = result << 8 | source[index++];

		return result;
	}

	public static ulong ReadULong(this byte[] source, ref int index, in byte valueByteCount = 16) {
		ulong result = 0;

		for (int i = 0; i < valueByteCount; i++)
			result = result << 8 | source[index++];

		return result;
	}

	#endregion
}
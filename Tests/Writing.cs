using BitwiseEx;

namespace Tests.BitwiseEx;

[TestClass]
public class Writing {
	static void PrepareWriteNumber(byte[] destination, ref int index) {
		Array.Clear(destination);
		index = 0;
	}

	static void AssertWriteNumber(byte[] destination, ref int index, in byte valueByteCount, byte[] expected) {
		CollectionAssert.AreEqual(expected, destination);
		Assert.AreEqual(valueByteCount, index);
	}

	[TestMethod]
	public void WriteInt() {
		byte[] destination = new byte[4];
		int index = 0;

		void assert(int value, byte valueByteCount, params byte[] expected) {
			PrepareWriteNumber(destination, ref index);
			destination.Write(ref index, in value, in valueByteCount);
			AssertWriteNumber(destination, ref index, in valueByteCount, expected);
		}

		assert(0x11_22_33_44, 4, 0x11, 0x22, 0x33, 0x44);
		assert(0x11_22_33_44, 3, 0x22, 0x33, 0x44, 0x00);
		assert(0x11_22_33_44, 2, 0x33, 0x44, 0x00, 0x00);
		assert(0x11_22_33_44, 1, 0x44, 0x00, 0x00, 0x00);
	}

	[TestMethod]
	public void WriteUInt() {
		byte[] destination = new byte[4];
		int index = 0;

		void assert(uint value, byte valueByteCount, params byte[] expected) {
			PrepareWriteNumber(destination, ref index);
			destination.Write(ref index, in value, in valueByteCount);
			AssertWriteNumber(destination, ref index, in valueByteCount, expected);
		}

		assert(0xAA_BB_CC_DD, 4, 0xAA, 0xBB, 0xCC, 0xDD);
		assert(0xAA_BB_CC_DD, 3, 0xBB, 0xCC, 0xDD, 0x00);
		assert(0xAA_BB_CC_DD, 2, 0xCC, 0xDD, 0x00, 0x00);
		assert(0xAA_BB_CC_DD, 1, 0xDD, 0x00, 0x00, 0x00);
	}

	[TestMethod]
	public void WriteLong() {
		byte[] destination = new byte[8];
		int index = 0;

		void assert(long value, byte valueByteCount, params byte[] expected) {
			PrepareWriteNumber(destination, ref index);
			destination.Write(ref index, in value, in valueByteCount);
			AssertWriteNumber(destination, ref index, in valueByteCount, expected);
		}

		assert(0x11_22_33_44_55_66_77_88, 8, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88);
		assert(0x11_22_33_44_55_66_77_88, 7, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x00);
		assert(0x11_22_33_44_55_66_77_88, 6, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x00, 0x00);
		assert(0x11_22_33_44_55_66_77_88, 5, 0x44, 0x55, 0x66, 0x77, 0x88, 0x00, 0x00, 0x00);
	}

	[TestMethod]
	public void WriteULong() {
		byte[] destination = new byte[8];
		int index = 0;

		void assert(ulong value, byte valueByteCount, params byte[] expected) {
			PrepareWriteNumber(destination, ref index);
			destination.Write(ref index, in value, in valueByteCount);
			AssertWriteNumber(destination, ref index, in valueByteCount, expected);
		}

		assert(0x88_99_AA_BB_CC_DD_EE_FF, 8, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF);
		assert(0x88_99_AA_BB_CC_DD_EE_FF, 7, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF, 0x00);
		assert(0x88_99_AA_BB_CC_DD_EE_FF, 6, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF, 0x00, 0x00);
		assert(0x88_99_AA_BB_CC_DD_EE_FF, 5, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF, 0x00, 0x00, 0x00);
	}

	[TestMethod]
	public void ReadInt() {
		int index;

		void assert(byte[] source, byte valueByteCount, int expected, bool littleEndian) {
			index = 0;

			var value = source.ReadInt(ref index, in valueByteCount, littleEndian);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(index, valueByteCount);
		}

		assert(new byte[] { 0x11, 0x22, 0x33, 0x44 }, 4, 0x11_22_33_44, false);
		assert(new byte[] { 0x11, 0x22, 0x33, 0x44 }, 3, 0x00_11_22_33, false);
		assert(new byte[] { 0x11, 0x22, 0x33, 0x44 }, 2, 0x00_00_11_22, false);
		assert(new byte[] { 0x11, 0x22, 0x33, 0x44 }, 1, 0x00_00_00_11, false);
	}
}
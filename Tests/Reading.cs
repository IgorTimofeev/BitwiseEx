using BitwiseEx;

namespace Tests.BitwiseEx;

[TestClass]
public class Reading {
	[TestMethod]
	public void ReadInt() {
		int index;

		void assert(byte[] source, byte valueByteCount, int expected, bool littleEndian) {
			index = 0;

			var value = source.ReadInt(ref index, in valueByteCount, littleEndian);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0x11, 0x22, 0x33, 0x44 };

		assert(source, 4, 0x11_22_33_44, false);
		assert(source, 3, 0x00_11_22_33, false);
		assert(source, 2, 0x00_00_11_22, false);
		assert(source, 1, 0x00_00_00_11, false);
		
		assert(source, 4, 0x44_33_22_11, true);
		assert(source, 3, 0x00_33_22_11, true);
		assert(source, 2, 0x00_00_22_11, true);
		assert(source, 1, 0x00_00_00_11, true);
	}

	[TestMethod]
	public void ReadUInt() {
		int index;

		void assert(byte[] source, byte valueByteCount, uint expected, bool littleEndian) {
			index = 0;

			var value = source.ReadUInt(ref index, in valueByteCount, littleEndian);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD };

		assert(source, 4, 0xAA_BB_CC_DD, false);
		assert(source, 3, 0x00_AA_BB_CC, false);
		assert(source, 2, 0x00_00_AA_BB, false);
		assert(source, 1, 0x00_00_00_AA, false);

		assert(source, 4, 0xDD_CC_BB_AA, true);
		assert(source, 3, 0x00_CC_BB_AA, true);
		assert(source, 2, 0x00_00_BB_AA, true);
		assert(source, 1, 0x00_00_00_AA, true);
	}

	[TestMethod]
	public void ReadLong() {
		int index;

		void assert(byte[] source, byte valueByteCount, long expected, bool littleEndian) {
			index = 0;

			var value = source.ReadLong(ref index, in valueByteCount, littleEndian);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77 };

		assert(source, 8, 0x00_11_22_33_44_55_66_77, false);
		assert(source, 7, 0x00_00_11_22_33_44_55_66, false);
		assert(source, 6, 0x00_00_00_11_22_33_44_55, false);
		assert(source, 5, 0x00_00_00_00_11_22_33_44, false);

		assert(source, 8, 0x77_66_55_44_33_22_11_00, true);
		assert(source, 7, 0x00_66_55_44_33_22_11_00, true);
		assert(source, 6, 0x00_00_55_44_33_22_11_00, true);
		assert(source, 5, 0x00_00_00_44_33_22_11_00, true);
	}

	[TestMethod]
	public void ReadULong() {
		int index;

		void assert(byte[] source, byte valueByteCount, ulong expected, bool littleEndian) {
			index = 0;

			var value = source.ReadULong(ref index, in valueByteCount, littleEndian);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };

		assert(source, 8, 0x88_99_AA_BB_CC_DD_EE_FF, false);
		assert(source, 7, 0x00_88_99_AA_BB_CC_DD_EE, false);
		assert(source, 6, 0x00_00_88_99_AA_BB_CC_DD, false);
		assert(source, 5, 0x00_00_00_88_99_AA_BB_CC, false);

		assert(source, 8, 0xFF_EE_DD_CC_BB_AA_99_88, true);
		assert(source, 7, 0x00_EE_DD_CC_BB_AA_99_88, true);
		assert(source, 6, 0x00_00_DD_CC_BB_AA_99_88, true);
		assert(source, 5, 0x00_00_00_CC_BB_AA_99_88, true);
	}
}
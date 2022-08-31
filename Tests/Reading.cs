using BitwiseEx;

namespace Tests.BitwiseEx;

[TestClass]
public class Reading {
	[TestMethod]
	public void ReadInt() {
		int index;

		void assert(byte[] source, byte valueByteCount, int expected) {
			index = 0;

			var value = source.ReadInt(ref index, in valueByteCount);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0x11, 0x22, 0x33, 0x44 };

		assert(source, 4, 0x11_22_33_44);
		assert(source, 3, 0x00_11_22_33);
		assert(source, 2, 0x00_00_11_22);
		assert(source, 1, 0x00_00_00_11);
	}

	[TestMethod]
	public void ReadUInt() {
		int index;

		void assert(byte[] source, byte valueByteCount, uint expected) {
			index = 0;

			var value = source.ReadUInt(ref index, in valueByteCount);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD };

		assert(source, 4, 0xAA_BB_CC_DD);
		assert(source, 3, 0x00_AA_BB_CC);
		assert(source, 2, 0x00_00_AA_BB);
		assert(source, 1, 0x00_00_00_AA);
	}

	[TestMethod]
	public void ReadLong() {
		int index;

		void assert(byte[] source, byte valueByteCount, long expected) {
			index = 0;

			var value = source.ReadLong(ref index, in valueByteCount);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77 };

		assert(source, 8, 0x00_11_22_33_44_55_66_77);
		assert(source, 7, 0x00_00_11_22_33_44_55_66);
		assert(source, 6, 0x00_00_00_11_22_33_44_55);
		assert(source, 5, 0x00_00_00_00_11_22_33_44);
	}

	[TestMethod]
	public void ReadULong() {
		int index;

		void assert(byte[] source, byte valueByteCount, ulong expected) {
			index = 0;

			var value = source.ReadULong(ref index, in valueByteCount);

			Assert.AreEqual(expected, value);
			Assert.AreEqual(valueByteCount, index);
		}

		var source = new byte[] { 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };

		assert(source, 8, 0x88_99_AA_BB_CC_DD_EE_FF);
		assert(source, 7, 0x00_88_99_AA_BB_CC_DD_EE);
		assert(source, 6, 0x00_00_88_99_AA_BB_CC_DD);
		assert(source, 5, 0x00_00_00_88_99_AA_BB_CC);
	}
}
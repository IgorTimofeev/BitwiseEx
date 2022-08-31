using BitwiseEx.Protocol;
using System.Text;

namespace Tests.BitwiseEx;

[TestClass]
public class Protocol {
	static void PrepareEncode(byte[] destination, ref int index) {
		Array.Clear(destination);
		index = 0;
	}

	static void AssertEncodeNumber(byte[] destination, ref int index, in byte valueByteCount, byte[] expected) {
		CollectionAssert.AreEqual(expected, destination);
		Assert.AreEqual(valueByteCount + 1, index);
	}

	[TestMethod]
	public void EncodeInt() {
		byte[] destination = new byte[5];
		int index = 0;

		void assertAny(int value, byte valueByteCount, params byte[] expected) {
			PrepareEncode(destination, ref index);
			destination.Encode(ref index, in value, in valueByteCount);
			AssertEncodeNumber(destination, ref index, in valueByteCount, expected);
		}

		void assertPositiveAndNegative(int value, byte valueByteCount, params byte[] expected) {
			byte[] prefixedExpected = new byte[1 + expected.Length];
			Array.Copy(expected, 0, prefixedExpected, 1, expected.Length);

			prefixedExpected[0] = (byte) ((valueByteCount - 1) << 1 | 0);
			assertAny(+value, valueByteCount, prefixedExpected);

			prefixedExpected[0] = (byte) ((valueByteCount - 1) << 1 | 1);
			assertAny(-value, valueByteCount, prefixedExpected);
		}

		assertPositiveAndNegative(0x11_22_33_44, 4, 0x11, 0x22, 0x33, 0x44);
		assertPositiveAndNegative(0x11_22_33_44, 3, 0x22, 0x33, 0x44, 0x00);
		assertPositiveAndNegative(0x11_22_33_44, 2, 0x33, 0x44, 0x00, 0x00);
		assertPositiveAndNegative(0x11_22_33_44, 1, 0x44, 0x00, 0x00, 0x00);
	}

	[TestMethod]
	public void DecodeInt() {
		int index;

		void assert(byte[] source, int expected) {
			index = 0;
			var result = source.DecodeInt(ref index);
			Assert.AreEqual(expected, result);
		}

		assert(new byte[] { 3 << 1 | 0, 0x11, 0x22, 0x33, 0x44 }, +0x11_22_33_44);
		assert(new byte[] { 3 << 1 | 1, 0x11, 0x22, 0x33, 0x44 }, -0x11_22_33_44);

		assert(new byte[] { 2 << 1 | 0, 0x22, 0x33, 0x44 }, +0x22_33_44);
		assert(new byte[] { 2 << 1 | 1, 0x22, 0x33, 0x44 }, -0x22_33_44);

		assert(new byte[] { 1 << 1 | 0, 0x33, 0x44 }, +0x33_44);
		assert(new byte[] { 1 << 1 | 1, 0x33, 0x44 }, -0x33_44);

		assert(new byte[] { 0 << 1 | 0, 0x44 }, +0x44);
		assert(new byte[] { 0 << 1 | 1, 0x44 }, -0x44);
	}

	[TestMethod]
	public void EncodeUInt() {
		byte[] destination = new byte[5];
		int index = 0;

		void assert(uint value, byte valueByteCount, params byte[] expected) {
			PrepareEncode(destination, ref index);
			destination.Encode(ref index, in value, in valueByteCount);
			AssertEncodeNumber(destination, ref index, in valueByteCount, expected);
		}

		assert(0xAA_BB_CC_DD, 4, 0x03, 0xAA, 0xBB, 0xCC, 0xDD);
		assert(0xAA_BB_CC_DD, 3, 0x02, 0xBB, 0xCC, 0xDD, 0x00);
		assert(0xAA_BB_CC_DD, 2, 0x01, 0xCC, 0xDD, 0x00, 0x00);
		assert(0xAA_BB_CC_DD, 1, 0x00, 0xDD, 0x00, 0x00, 0x00);
	}

	[TestMethod]
	public void DecodeUInt() {
		int index;

		void assert(byte[] source, uint expected) {
			index = 0;
			var result = source.DecodeUInt(ref index);
			Assert.AreEqual(expected, result);
		}

		assert(new byte[] { 0x03, 0xAA, 0xBB, 0xCC, 0xDD }, 0xAA_BB_CC_DD);
		assert(new byte[] { 0x02, 0xBB, 0xCC, 0xDD, 0x00 }, 0xBB_CC_DD);
		assert(new byte[] { 0x01, 0xCC, 0xDD, 0x00, 0x00 }, 0xCC_DD);
		assert(new byte[] { 0x00, 0xDD, 0x00, 0x00, 0x00 }, 0xDD);
	}

	[TestMethod]
	public void EncodeString() {
		byte[] destination;
		int index;

		void assert(string value, params byte[] expected) {
			destination = new byte[2 + value.Length];
			index = 0;

			destination.Encode(ref index, in value, Encoding.UTF8);

			CollectionAssert.AreEqual(expected, destination);
			Assert.AreEqual(2 + value.Length, index);
		}

		assert("Hello", 0, 5, 72, 101, 108, 108, 111);
		assert("world", 0, 5, 119, 111, 114, 108, 100);
		assert("this works very nice!", 0, 21, 116, 104, 105, 115, 32, 119, 111, 114, 107, 115, 32, 118, 101, 114, 121, 32, 110, 105, 99, 101, 33);
	}

	[TestMethod]
	public void DecodeString() {
		int index;

		void assert(byte[] source, string expected) {
			index = 0;

			var result = source.DecodeString(ref index, Encoding.UTF8);

			Assert.AreEqual(expected, result);
			Assert.AreEqual(2 + expected.Length, index);
		}

		assert(new byte[] { 0, 5, 72, 101, 108, 108, 111 }, "Hello");
		assert(new byte[] { 0, 5, 119, 111, 114, 108, 100 }, "world");
		assert(new byte[] { 0, 21, 116, 104, 105, 115, 32, 119, 111, 114, 107, 115, 32, 118, 101, 114, 121, 32, 110, 105, 99, 101, 33 }, "this works very nice!");
	}
}
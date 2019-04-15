using System;
using Xunit;

namespace ITnmg.HexConvert.XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ByteToHex()
        {
            var bytes = new byte[] { 0xAA, 0xBB, 0xCC };

            Assert.Equal( "AA BB CC" , bytes.ToHexString( " " ));
        }

        [Fact]
        public void HexToBytesException()
        {
            var str = "AA BB CC";
            str.ToBytes();
        }

        [Fact]
        public void HexToBytes()
        {
            var str = "AA BB CC";
            Assert.Equal( new byte[] { }, str.ToBytes() );
        }

        [Fact]
        public void IsHex()
        {
            var str = "aa,bb,cc";
            Assert.True( str.IsHexString( "," ) );
        }

        [Fact]
        public void IsNotHex()
        {
            var str = "aa bb kk";
            Assert.False( str.IsHexString( " " ) );
        }
    }
}

using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ByteToHex()
        {
            var bytes = new byte[] { 0xAA, 0xBB, 0xCC };
            Assert.AreEqual( "AA BB CC", bytes.ToHexString( " " ) );
        }

        [Test]
        public void HexToBytes()
        {
            string str = null;
            Assert.Throws<ArgumentNullException>( () => str.ToBytes() );

            str = "AA BB kk";
            Assert.Throws<ArgumentException>( () => str.ToBytes() );

            str = "AABBCC";
            CollectionAssert.AreEqual( new byte[] { 0xAA, 0xBB, 0xCC }, str.ToBytes( " " ) );
            CollectionAssert.AreEqual( new byte[] { 0xAA, 0xBB, 0xCC }, str.ToBytes() );
        }

        [Test]
        public void IsHex()
        {
            var str = "aa,bb,cc";
            Assert.True( str.IsHexString( "," ) );

            str = "aa bb kk";
            Assert.False( str.IsHexString( " " ) );
        }
    }
}
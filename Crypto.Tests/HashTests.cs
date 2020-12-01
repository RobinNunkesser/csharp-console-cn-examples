using System;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;

namespace Crypto.Tests
{
    public class HashTests
    {
        private const string Plaintext = "Data to compute hash for";
        private const string ExpectedHash = "46-CD-85-07-8D-27-32-1D-76-15-28-0F-F8-34-82-A5-DD-09-64-60";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSHA1()
        {
            byte[] data = Encoding.UTF8.GetBytes(Plaintext);
            byte[] result;
            SHA1 shaM = new SHA1Managed();
            result = shaM.ComputeHash(data);
            Assert.AreEqual(ExpectedHash, BitConverter.ToString(result));            
        }

    }
}

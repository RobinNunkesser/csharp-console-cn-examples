using System;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Crypto.Tests
{
    public class AsymTests
    {
        private const string Plaintext = "Hello World!";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRSA()
        {
            try
            {
                using RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                var encryptedData = RSACSPSample.RSAEncrypt(Plaintext, RSA.ExportParameters(false), false);
                var decryptedData = RSACSPSample.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
                Assert.AreEqual(Plaintext, decryptedData);
            }
            catch (ArgumentNullException e)
            {
                Assert.Fail(e.Message);

            }
        }

    }
}

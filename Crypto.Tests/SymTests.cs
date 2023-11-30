using System.Security.Cryptography;
using NUnit.Framework;

namespace Crypto.Tests
{
    public class SymTests
    {
        private const string Plaintext = "Hello World!";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDES()
        {
            var des = new SymCrypt(new DESCryptoServiceProvider());
            var encrypted = des.EncryptData(Plaintext);
            var decrypted = des.DecryptData(encrypted);
            Assert.AreEqual(Plaintext, decrypted);
        }

        [Test]
        public void TestTripleDES()
        {
            var tripleDes = new SymCrypt(new TripleDESCryptoServiceProvider());
            var encrypted = tripleDes.EncryptData(Plaintext);
            var decrypted = tripleDes.DecryptData(encrypted);
            Assert.AreEqual(Plaintext, decrypted);
        }

        [Test]
        public void TestAES()
        {
            var aes = new SymCrypt(new AesManaged());
            var encrypted = aes.EncryptData(Plaintext);
            var decrypted = aes.DecryptData(encrypted);
            Assert.AreEqual(Plaintext, decrypted);
        }
    }
}
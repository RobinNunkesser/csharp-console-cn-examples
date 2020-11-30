using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    public class SymCrypt
    {
        byte[] key;
        byte[] IV;
        SymmetricAlgorithm symAlg;

        public SymCrypt(SymmetricAlgorithm symAlg, string strKey = null, byte[] IV = null)
        {
            this.symAlg = symAlg;
            if (strKey != null)
            {
                key = Encoding.UTF8.GetBytes(strKey);
                symAlg.Key = key;
            }
            else
            {
                symAlg.GenerateKey();
                key = symAlg.Key;
            }
            if (IV != null)
            {
                this.IV = IV;
                symAlg.IV = IV;
            }
            else
            {
                symAlg.GenerateIV();
                IV = symAlg.IV;
            }

        }

        public string EncryptData(string strData)
        {
            Console.WriteLine($"Plaintext:                {strData}");
            byte[] inputByteArray;

            try
            {            
                Console.WriteLine($"Key (bytes):              {BitConverter.ToString(symAlg.Key)}");
                Console.WriteLine($"IV (bytes):               {BitConverter.ToString(symAlg.IV)}");
                inputByteArray = Encoding.UTF8.GetBytes(strData);
                var memoryStream = new MemoryStream();
                var encryptor = symAlg.CreateEncryptor(symAlg.Key, symAlg.IV);

                var cryptoStream = new CryptoStream(memoryStream, encryptor
                , CryptoStreamMode.Write);
                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();

                var cipher = memoryStream.ToArray();

                Console.WriteLine($"Encrypted cipher (bytes): {BitConverter.ToString(cipher)}");

                return Convert.ToBase64String(cipher);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DecryptData(string strData)
        {
            byte[] inputByteArray = new byte[strData.Length];

            try
            {
                inputByteArray = Convert.FromBase64String(strData);

                var memoryStream = new MemoryStream();
                var decryptor = symAlg.CreateDecryptor(symAlg.Key, symAlg.IV);
                var cryptoStream = new CryptoStream(memoryStream,
                 decryptor, CryptoStreamMode.Write);
                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();

                var decryptedText = Encoding.UTF8.GetString(memoryStream.ToArray());
                Console.WriteLine($"Decrypted text:           {decryptedText}");

                return decryptedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

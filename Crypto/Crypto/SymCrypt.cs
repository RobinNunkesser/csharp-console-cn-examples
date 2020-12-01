using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    public class SymCrypt
    {        
        readonly SymmetricAlgorithm symAlg;

        public SymCrypt(SymmetricAlgorithm symAlg, string strKey = null, byte[] IV = null)
        {
            this.symAlg = symAlg;
            switch (strKey)
            {
                case null:
                    symAlg.GenerateKey();                    
                    break;
                default:                    
                    symAlg.Key = Encoding.UTF8.GetBytes(strKey);
                    break;
            }
            switch (IV)
            {
                case null:
                    symAlg.GenerateIV();
                    break;
                default:
                    symAlg.IV = IV;
                    break;
            }
        }

        public string EncryptData(string strData)
        {
            byte[] inputByteArray;

            try
            {
                inputByteArray = Encoding.UTF8.GetBytes(strData);
                var memoryStream = new MemoryStream();
                var encryptor = symAlg.CreateEncryptor(symAlg.Key, symAlg.IV);

                var cryptoStream = new CryptoStream(memoryStream, encryptor
                , CryptoStreamMode.Write);
                cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                cryptoStream.FlushFinalBlock();

                var cipher = memoryStream.ToArray();

                return Convert.ToBase64String(cipher);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DecryptData(string strData)
        {
            byte[] inputByteArray;

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

                return decryptedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{

    class RSACSPSample
    {

        public static byte[] RSAEncrypt(string strData, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider rsa = null;
            try
            {
                rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(RSAKeyInfo);
                var encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(strData), DoOAEPPadding);
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                rsa?.Dispose();
            }
        }

        public static string RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider rsa = null;
            try
            {
                rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(RSAKeyInfo);
                var decryptedData = rsa.Decrypt(DataToDecrypt, DoOAEPPadding);
                return Encoding.UTF8.GetString(decryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                rsa?.Dispose();
            }
        }
    }
}

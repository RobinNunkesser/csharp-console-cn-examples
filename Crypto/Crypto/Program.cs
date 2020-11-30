using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    class Program
    {
        static void AsymExample()
        {

            try
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Pass the data to ENCRYPT, the public key information 
                    //(using RSACryptoServiceProvider.ExportParameters(false),
                    //and a boolean flag specifying no OAEP padding.
                    var encryptedData = RSACSPSample.RSAEncrypt("Data to Encrypt", RSA.ExportParameters(false), false);

                    //Pass the data to DECRYPT, the private key information 
                    //(using RSACryptoServiceProvider.ExportParameters(true),
                    //and a boolean flag specifying no OAEP padding.
                    var decryptedData = RSACSPSample.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                    //Display the decrypted plaintext to the console. 
                    Console.WriteLine("Decrypted plaintext: {0}", decryptedData);
                }
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");

            }
        }

        static void HashExample()
        {
            byte[] data = Encoding.UTF8.GetBytes("Data to compute hash for");
            byte[] result;
            SHA1 shaM = new SHA1Managed();
            result = shaM.ComputeHash(data);
            Console.WriteLine($"Computed hash: {BitConverter.ToString(result)}");
        }

        static void Main(string[] args)
        {
            //AsymExample();
            //HashExample();
        }

    }
}

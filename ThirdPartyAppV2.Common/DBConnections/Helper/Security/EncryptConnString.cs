using PostSharp.Patterns.Diagnostics;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ThirdPartyAppV2.Common.DBConnections.Helper.Security
{
    public class EncryptConnString
    {
        private readonly string pwd1 = "SG93YXJkIEh1YmJhcmQgTWVtb3JpYWwgSG9zcGl0YWwgMjAyMw";
        private readonly string pwd2 = "SEhNSC4yMDIz";

        [return: NotLogged]
        private byte[] GenerateSaltedHash(byte[] salt1, byte[] salt2)
        {
            HashAlgorithm algorithm;
            using (algorithm = new SHA512Managed())
            {
                byte[] plainTextWithSaltBytes =
                  new byte[salt1.Length + salt2.Length];
                for (int i = 0; i < salt1.Length; i++)
                {
                    plainTextWithSaltBytes[i] = salt1[i];
                }
                for (int i = 0; i < salt2.Length; i++)
                {
                    plainTextWithSaltBytes[salt1.Length + i] = salt2[i];
                }
                return algorithm.ComputeHash(plainTextWithSaltBytes);
            }
        }

        /// <summary>
        /// Method which does the encryption using Rijndeal algorithm
        /// </summary>
        /// <param name="InputText">Data to be encrypted</param>
        /// <param name="Key">
        /// The string to used for making the key.The same string should be used for making the
        /// decrpt key
        /// </param>
        /// <returns>Encrypted Data</returns>
        [return: NotLogged]
        private string EncryptString(string InputText, string Key)
        {
            using (RijndaelManaged RijndaelCipher = new())
            {
                RijndaelCipher.Padding = PaddingMode.ISO10126;
                RijndaelCipher.Mode = CipherMode.CBC;
                RijndaelCipher.KeySize = 256;
                RijndaelCipher.BlockSize = 256;

                byte[] PlainText = Encoding.Unicode.GetBytes(InputText);
                byte[] Salt = Encoding.Unicode.GetBytes(Key);

                //This class uses an extension of the PBKDF1 algorithm defined in the PKCS#5 v2.0
                //standard to derive bytes suitable for use as key material from a password.
                //The standard is documented in IETF RRC 2898.

                using (Rfc2898DeriveBytes SecretKey = new(Key, Salt, 100, HashAlgorithmName.SHA512))
                {
                    //Creates a symmetric encryptor object.
                    ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(32));
                    System.IO.MemoryStream memoryStream = new();
                    //Defines a stream that links data streams to cryptographic transformations
                    CryptoStream cryptoStream = new(memoryStream, Encryptor, CryptoStreamMode.Write);
                    cryptoStream.Write(PlainText, 0, PlainText.Length);
                    //Writes the final state and clears the buffer
                    cryptoStream.FlushFinalBlock();
                    byte[] CipherBytes = memoryStream.ToArray();
                    memoryStream.Close();
                    cryptoStream.Close();
                    string EncryptedData = Convert.ToBase64String(CipherBytes);
                    return EncryptedData;
                }
            }
        } //eof private static string EncryptString ( string InputText, string Password )

        [return: NotLogged]
        private string DecryptString(string InputText, string Key)
        {
            try
            {
                using (RijndaelManaged RijndaelCipher = new())
                {
                    RijndaelCipher.Padding = PaddingMode.ISO10126;
                    RijndaelCipher.Mode = CipherMode.CBC;
                    RijndaelCipher.KeySize = 256;
                    RijndaelCipher.BlockSize = 256;

                    byte[] EncryptedData = Convert.FromBase64String(InputText);
                    byte[] Salt = Encoding.Unicode.GetBytes(Key);

                    //Making of the key for decryption
                    using (Rfc2898DeriveBytes SecretKey = new(Key, Salt, 100, HashAlgorithmName.SHA512))
                    {
                        //Creates a symmetric Rijndael decryptor object.
                        ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(32));
                        System.IO.MemoryStream memoryStream = new(EncryptedData);
                        //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                        CryptoStream cryptoStream = new(memoryStream, Decryptor, CryptoStreamMode.Read);
                        byte[] PlainText = new byte[EncryptedData.Length];
                        int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                        memoryStream.Close();
                        cryptoStream.Close();
                        //Converting to string
                        string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
                        return DecryptedData;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        } //eof private static string DecryptString (string InputText , string Password )

        [return: NotLogged]
        public string Encrypt(string stringToEncrypt)
        {
            var key = Convert.ToBase64String(GenerateSaltedHash(Encoding.Default.GetBytes(pwd1), Encoding.Default.GetBytes(pwd2)));
            var result = EncryptString(stringToEncrypt, key);
            return result;
        }

        [return: NotLogged]
        public string Decrypt(string stringToDecrypt)
        {
            var key = Convert.ToBase64String(GenerateSaltedHash(Encoding.Default.GetBytes(pwd1), Encoding.Default.GetBytes(pwd2)));
            var result = DecryptString(stringToDecrypt, key);
            return result;
        }
    }
}


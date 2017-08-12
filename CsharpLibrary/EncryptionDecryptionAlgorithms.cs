using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace CsharpLibrary
{
    public class EncryptionDecryptionAlgorithms
    {
        //We cannot decrypt data using MD5 algorithm as it is one way algorithm
        public class HashAlgorithms
        {
            /// <summary>
            /// Method encrypts plain text to encrypted text
            /// </summary>
            /// <param name="plainText">Plain text</param>
            /// <param name="useHashing">Compute hash or not</param>
            /// <returns>Ciphered text</returns>
            public string EncryptText(string plainText, bool useHashing, HashName hashName)
            {
                string cipherText = string.Empty;
                byte[] arrayToEncrypt = Encoding.UTF8.GetBytes(plainText);
                StringBuilder sbEncryptedText = new StringBuilder();

                HashAlgorithm hash = null;
                if (useHashing)
                {
                    switch (hashName)
                    {
                        case HashName.SHA1:
                            hash = SHA1.Create();
                            break;
                        case HashName.SHA256:
                            hash = SHA256.Create();
                            break;
                        case HashName.SHA384:
                            hash = SHA384.Create();
                            break;
                        case HashName.SHA512:
                            hash = SHA512.Create();
                            break;
                        default:
                            hash = MD5.Create();
                            break;
                    }

                    byte[] encryptedArray = hash.ComputeHash(arrayToEncrypt);

                    for (int i = 0; i < encryptedArray.Length; i++)
                    {
                        sbEncryptedText.Append(encryptedArray[i].ToString("x2"));
                    }
                    cipherText = sbEncryptedText.ToString();
                }
                else
                {
                    for (int i = 0; i < arrayToEncrypt.Length; i++)
                    {
                        sbEncryptedText.Append(arrayToEncrypt[i].ToString("x2"));
                    }
                    cipherText = sbEncryptedText.ToString();
                }

                return cipherText;
            }
        }

        public enum HashName
        {
            SHA1 = 1,
            MD5 = 2,
            SHA256 = 4,
            SHA384 = 8,
            SHA512 = 16
        }
    }
}

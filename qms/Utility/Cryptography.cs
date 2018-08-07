using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace qms.Utility
{
    public class Cryptography
    {
        public static string Encrypto(string value)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(value));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();

        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("SubraQMS"));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes("SubraQMS");

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("SubraQMS"));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes("SubraQMS");
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static bool Verify(string stringValue, string encryptedValue)
        {
            // Hash the input.
            string hashOfInput = Encrypto(stringValue);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, encryptedValue))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }


    public class clsCrypto
    {
        private string _KEY = string.Empty;
        protected internal string KEY
        {
            get
            {
                return _KEY;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _KEY = value;
                }
            }
        }

        private string _IV = string.Empty;
        protected internal string IV
        {
            get
            {
                return _IV;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _IV = value;
                }
            }
        }

        private string CalcMD5(string strInput)
        {
            string strOutput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                try
                {
                    StringBuilder strHex = new StringBuilder();
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] bytArText = Encoding.Default.GetBytes(strInput);
                        byte[] bytArHash = md5.ComputeHash(bytArText);
                        for (int i = 0; i < bytArHash.Length; i++)
                        {
                            strHex.Append(bytArHash[i].ToString("X2"));
                        }
                        strOutput = strHex.ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return strOutput;
        }

        private byte[] GetBytesFromHexString(string strInput)
        {
            byte[] bytArOutput = new byte[] { };
            if ((!string.IsNullOrEmpty(strInput)) && strInput.Length % 2 == 0)
            {
                SoapHexBinary hexBinary = null;
                try
                {
                    hexBinary = SoapHexBinary.Parse(strInput);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                bytArOutput = hexBinary.Value;
            }
            return bytArOutput;
        }

        private byte[] GenerateIV()
        {
            byte[] bytArOutput = new byte[] { };
            try
            {
                string strIV = CalcMD5(IV);
                bytArOutput = GetBytesFromHexString(strIV);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bytArOutput;
        }

        private byte[] GenerateKey()
        {
            byte[] bytArOutput = new byte[] { };
            try
            {
                string strKey = CalcMD5(KEY);
                bytArOutput = GetBytesFromHexString(strKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bytArOutput;
        }

        protected internal string Encrypt(string strInput, CipherMode cipherMode)
        {
            string strOutput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                try
                {
                    byte[] bytePlainText = Encoding.Default.GetBytes(strInput);
                    using (RijndaelManaged rijManaged = new RijndaelManaged())
                    {
                        rijManaged.Mode = cipherMode;
                        rijManaged.BlockSize = 128;
                        rijManaged.KeySize = 128;
                        rijManaged.IV = GenerateIV();
                        rijManaged.Key = GenerateKey();
                        rijManaged.Padding = PaddingMode.Zeros;
                        ICryptoTransform icpoTransform = rijManaged.CreateEncryptor(rijManaged.Key, rijManaged.IV);
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            using (CryptoStream cpoStream = new CryptoStream(memStream, icpoTransform, CryptoStreamMode.Write))
                            {
                                cpoStream.Write(bytePlainText, 0, bytePlainText.Length);
                                cpoStream.FlushFinalBlock();
                            }
                            strOutput = Encoding.Default.GetString(memStream.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return strOutput;
        }

        protected internal string Decrypt(string strInput, CipherMode cipherMode)
        {
            string strOutput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                try
                {
                    byte[] byteCipherText = Encoding.Default.GetBytes(strInput);
                    byte[] byteBuffer = new byte[strInput.Length];
                    using (RijndaelManaged rijManaged = new RijndaelManaged())
                    {
                        rijManaged.Mode = cipherMode;
                        rijManaged.BlockSize = 128;
                        rijManaged.KeySize = 128;
                        rijManaged.IV = GenerateIV();
                        rijManaged.Key = GenerateKey();
                        rijManaged.Padding = PaddingMode.Zeros;
                        ICryptoTransform icpoTransform = rijManaged.CreateDecryptor(rijManaged.Key, rijManaged.IV);
                        using (MemoryStream memStream = new MemoryStream(byteCipherText))
                        {
                            using (CryptoStream cpoStream = new CryptoStream(memStream, icpoTransform, CryptoStreamMode.Read))
                            {
                                cpoStream.Read(byteBuffer, 0, byteBuffer.Length);
                            }
                            strOutput = Encoding.Default.GetString(byteBuffer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return strOutput;
        }

    }
}
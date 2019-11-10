using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADSReminder.Utility.Security
{
    /// <summary>
    /// This class use for hashing operation.
    /// </summary>
    public static class Hasher
    {
        /// <summary>
        /// Hash the passing string with MD5 and returns the hashed value as string.
        /// </summary>
        /// <param name="argHashingValue"></param>
        /// <returns></returns>
        public static string fnHashString(string argHashingValue)
        {
            MD5 lcMd5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            lcMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(argHashingValue));

            //get hash result after compute it  
            byte[] lcResult = lcMd5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < lcResult.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(lcResult[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}

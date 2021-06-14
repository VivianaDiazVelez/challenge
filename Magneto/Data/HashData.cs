using System;
using System.Security.Cryptography;
using System.Text;

namespace Magneto.Data
{
    public class HashData
    {
        public string CreateHash(string input)
        {
            HashAlgorithm sha = SHA256.Create();
            byte[] hashData = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hashData);
        }
    }
}

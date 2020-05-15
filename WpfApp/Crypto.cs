using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

// * ***************************************************************************************************************
// *  NOTE!!!
// * 
// * This code is duplicated in BlazorWebBug.Client and WpfApp because it can NOT be put in a shared library.
// * .NET Standard 2.0 does NOT support the same Rfc2898DeriveBytes API as used below.
// *  
// * ***************************************************************************************************************

namespace Test
    {
    class Crypto
        {
        public byte[] GetHashBytes(string password, byte[] salt, int iterations, int outputBytes)
            {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512);
            return pbkdf2.GetBytes(outputBytes);
            }

        public byte[] Random(int cb)
            {
            byte[] random = new byte[cb];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                rng.GetBytes(random);
                }

            return random;
            }
        }
    }

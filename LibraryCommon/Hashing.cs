using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class Hashing
    {
        public string NoHashing(string inInputValue)
        {
            return inInputValue;
        }

        public string AdditiveHash(string inInputValue)
        {
            int _sum = 0;
            foreach (char _c in inInputValue)
            {
                _sum = _sum + Convert.ToInt32(_c);
            }
            return _sum.ToString();
        }

        public string SHA256HashNotSalted(string inInputValue)
        {
            HashAlgorithm _hashAlgorithm = new SHA256Managed();
            string _hash = String.Empty;
            byte[] _arrayBytes = _hashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(inInputValue));
            foreach (byte theByte in _arrayBytes)
            {
                _hash += theByte.ToString("x2");
            }
            return _hash;

        }

        public string SHA256HashWithSalt(string inInputValue, string inSalt)
        {
            // declaring variables - unuseful and unnecessary comment
            string _hashedValue = "";
            byte[] _plainTextByteArray = new byte[inInputValue.Length];
            byte[] _saltByteArray = new byte[inSalt.Length];
            byte[] _plainTextWithSaltBytes = new byte[_plainTextByteArray.Length + inSalt.Length];

            HashAlgorithm algorithm = new SHA256Managed();

            // get the bytes into their byte arrays using ASCII
            _plainTextByteArray = Encoding.ASCII.GetBytes(inInputValue);
            _saltByteArray = Encoding.ASCII.GetBytes(inSalt);

            // get the bytes into their byte arrays using Unicode
            //plainTextByteArray = Encoding.Unicode.GetBytes(inInputValue);
            //saltByteArray = Encoding.Unicode.GetBytes(inSalt);

            for (int i = 0; i < _plainTextByteArray.Length; i++)
            {
                _plainTextWithSaltBytes[i] = _plainTextByteArray[i];
            }

            // add to the final array
            for (int i = 0; i < inSalt.Length; i++)
            {
                // notice that indexer using the end for our first array as the starting location
                _plainTextWithSaltBytes[_plainTextByteArray.Length + i] = _saltByteArray[i];
            }

            // hash it SHA256 style !!!! as a byte[] array
            var _hashed = algorithm.ComputeHash(_plainTextWithSaltBytes);

            // btye[] to string
            _hashedValue = System.Text.Encoding.Default.GetString(_hashed);

            return _hashedValue;

        }
    }
}

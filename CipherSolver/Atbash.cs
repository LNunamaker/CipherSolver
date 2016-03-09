using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherSolver
{
    class Atbash : Cipher
    {

        public static string encode(object[] parameters)
        {
            string cipher = parameters[0].ToString().ToUpper();
            string decoded = "";
            int shift;
            foreach (char c in cipher)
            {
                shift = -25 + 2 * (90 - c);
                decoded = decoded + shifter(c, shift);
            }
            return decoded;
        }

        public static string decode(object[] parameters)
        {
            return encode(parameters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CipherSolver
{
    abstract class Cipher
    {
        protected static char shifter(char c, int shift)
        {
            if (!Char.IsLetter(c))
            {
                return c;
            }
            int shifted = c + shift;
            shifted = fix_shifted_alpha(shifted);
            return (char)shifted;
        }

        static char fix_shifted_alpha(int c)
        {
            if (c > 90)
            {
                c = 65 + (c - 91);
            }
            else if (c < 65)
            {
                c = 90 - (64 - c);
            }
            return (char)c;
        }
    }
}

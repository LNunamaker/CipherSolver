using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherSolver
{
    class Vigenere : Cipher
    {
        public static string encode(object[] parameters)
        {
            string cipher = parameters[0].ToString().ToUpper();
            //Console.Write("Enter Key: ");
            //string key = Console.ReadLine().ToUpper();
            string key = parameters[2].ToString().ToUpper();
            if (key == "")
            {
                return cipher;
            }
            string decoded = "";
            int spaces = 0;
            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] == ' ')
                {
                    decoded = decoded + ' ';
                    spaces++;
                }
                if (key[(i - spaces) % key.Length] == ' ')
                {
                    spaces--;
                }
                decoded = decoded + shifter(cipher[i], key[(i - spaces) % key.Length] - 65);
            }
            return decoded;
        }

        public static string decode(object[] parameters)
        {
            string cipher = parameters[0].ToString().ToUpper();
            //Console.Write("Enter Key: ");
            //string key = Console.ReadLine().ToUpper();
            string key = parameters[2].ToString();
            if (key == "")
            {
                return cipher;
            }
            string decoded = "";
            int spaces = 0;
            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] == ' ')
                {
                    decoded = decoded + ' ';
                    spaces++;
                }
                if (key[(i - spaces) % key.Length] == ' ')
                {
                    spaces--;
                }
                decoded = decoded + shifter(cipher[i], (key[(i - spaces) % key.Length] - 65) * -1);
            }
            return decoded;
        }
    }
}

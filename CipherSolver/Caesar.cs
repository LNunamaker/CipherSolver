using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherSolver
{
    class Caesar : Cipher
    {
        public static string encode(object[] parameters)
        {
            //Console.Write("Enter the shift: ");
            //string temp = Console.ReadLine();
            //shift = Convert.ToInt32(temp);
            return encodeDecodeHelper(parameters[0].ToString(), Convert.ToInt32(parameters[1]));
        }

        public static string decode(object[] parameters)
        {
            /*Console.Write("Enter the shift: ");
            string temp = Console.ReadLine();
            shift = Convert.ToInt32(temp);*/
            return encodeDecodeHelper(parameters[0].ToString(), Convert.ToInt32(parameters[1]) *-1);
        }

        static string encodeDecodeHelper(string cipherText, int shift)
        {
            cipherText = cipherText.ToUpper();
            string decoded = "";
            foreach (char character in cipherText)
            {
                decoded = decoded + shifter(character, shift);
            }
            return decoded;
        }
    }
}

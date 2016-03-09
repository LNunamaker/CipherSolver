using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CipherSolver
{
    class A1Z26 : Cipher
    {
        public static string encode(object[] parameters)
        {
            string encoded = "";
            string cipher = parameters[0].ToString().ToUpper();
            foreach (char c in cipher)
            {
                if (Char.IsLetter(c))
                {
                    encoded = encoded + (c - 64) + '-';
                }
                else
                {
                    encoded = encoded + c;
                }
            }
            return encoded;
        }

        public static string decode(object[] parameters)
        {
            string cipher = parameters[0].ToString();
            List<int> cipherInts = A1Z26_cleanse(cipher);
            string decoded = "";
            foreach (int i in cipherInts)
            {
                decoded = decoded + (char)(i + 64);
            }
            return decoded;
        }

        static List<int> A1Z26_cleanse(string cipher)
        {
            List<int> cipherints = new List<int>();
            cipher = " " + cipher + " ";
            MatchCollection mc1 = Regex.Matches(cipher, @"(?<=\ )(.*?)(?=\ )");
            foreach (Match m1 in mc1)
            {
                string temp = "-" + m1 + "-";
                MatchCollection mc2 = Regex.Matches(temp, @"(?<=\-)(.*?)(?=\-)");
                foreach (Match m2 in mc2)
                {
                    temp = "";
                    foreach (char c in m2.ToString())
                    {
                        if (!Char.IsDigit(c))
                        {
                            if (temp != "")
                            {
                                cipherints.Add(Convert.ToInt32(temp));
                            }
                            temp = (c - 64).ToString();
                            cipherints.Add(Convert.ToInt32(temp));
                            temp = "";
                        }
                        else
                            temp = temp + c;
                    }
                    if (temp != "")
                    {
                        cipherints.Add(Convert.ToInt32(temp));
                    }
                }
                cipherints.Add(-32);
            }
            return cipherints;
        }
    }
}

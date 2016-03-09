using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CipherSolver
{
    class ModifiedAffine : Cipher
    {
        public static string encode(object[] parameters)
        {       
            string cipher = parameters[0].ToString().ToUpper();
            cipher = " " + cipher + " ";
            MatchCollection mc = Regex.Matches(cipher, @"(?<=\ )(.*?)(?=\ )");
            string encoded = "";
            foreach (Match m in mc)
            {
                foreach (char c in m.ToString())
                {
                    int temp;
                    if (Char.IsLetter(c))
                    {
                        temp = ((c - 64) * m.Length) % 26;
                        if (temp == 0)
                        {
                            temp = 26;
                        }
                    }
                    else
                        temp = c - 64;
                    encoded = encoded + (char)(temp + 64);
                }
                encoded = encoded + " ";
            }
            return encoded;
        }

        public static string decode(object[] parameters)
        {
            List<string> mod_affine_word_list = new List<string>();
            string decoded = "";
            string cipher = parameters[0].ToString().ToUpper();
            cipher = " " + cipher + " ";
            MatchCollection mc = Regex.Matches(cipher, @"(?<=\ )(.*?)(?=\ )");
            List<List<char>> possibles = mod_affine_decode(mc);
            node start = new node(' ', possibles, 0);
            traverse(start, "", mod_affine_word_list);
            foreach (string word in mod_affine_word_list)
            {
                decoded = decoded + word + Environment.NewLine;
            }
            /*bool test = true;
            int count = 0;
            while(test){
                test = false;
                foreach (List<char> list in possibles)
                {
                    try
                    {
                        decoded = decoded + list[count];
                        test = true;
                    }
                    catch (Exception e)
                    {
                        decoded = decoded + " ";
                    }
                    
                }
                count++;
                decoded = decoded + Environment.NewLine;

            }*/
            return decoded;
        }

        static List<List<char>> mod_affine_decode(MatchCollection mc)
        {
            List<List<char>> possibles = new List<List<char>>();
            int count = 0;
            foreach (Match m in mc)
            {
                for (int i = 0; i < m.Length; i++)
                {
                    possibles.Add(new List<char>());
                    char c = m.ToString()[i];
                    if (Char.IsLetter(c))
                    {
                        for (int a = 0; a < m.Length; a++)
                        {
                            float canidate = ((c - 64) + (a * 26)) / (float)m.Length;
                            if (canidate % 1 == 0)
                            {
                                possibles[count].Add((char)(canidate + 64));
                            }
                        }
                    }
                    else
                        possibles[count].Add(c);
                    count++;
                }
                possibles.Add(new List<char>());
                possibles[count].Add(' ');
                count++;
            }
            return possibles;
        }

        static void traverse(node start, string decoded, List<string> mod_affine_word_list)
        {
            decoded = decoded + start.letter;
            if (start.nodes == null)
            {
                mod_affine_word_list.Add(decoded);
                return;
            }
            foreach (node next in start.nodes)
            {
                traverse(next, decoded, mod_affine_word_list);
            }
            return;
        }
    }
}

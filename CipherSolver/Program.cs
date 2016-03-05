using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CipherSolver
{
    class Program
    {
        static List<string> mod_affine_word_list;
        static void Main(string[] args)
        {
            mod_affine_word_list = new List<string>();
            string input;
            while (true)
            {
                Console.WriteLine("1. Caesar\n2. Atbash\n3. A1Z26\n4. Vigenere w/ Key\n5. Modified Affine");
                Console.Write("Select ciphers in order: ");
                input = Console.ReadLine();
                menu(input);
                Console.Write("Press q to quit: ");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }

        static void menu(string input)
        {
            Console.Write("Enter cipher: ");
            string cipher = Console.ReadLine();
            foreach(char c in input)
            {
                switch (c)
                {
                    case '1':
                        cipher = Caesar(cipher, 1);
                        Console.WriteLine("Caesar: " + cipher);
                        break;
                    case '2':
                        cipher = Atbash(cipher);
                        Console.WriteLine("Atbash: " + cipher);
                        break;
                    case '3':
                        cipher = A1Z26(cipher);
                        Console.WriteLine("A1Z26: " + cipher);
                        break;
                    case '4':
                        cipher = key_vigenere(cipher, 1);
                        Console.WriteLine("Vigenere: " + cipher);
                        break;
                    case '5':
                        cipher = mod_affine(cipher, 1);
                        Console.WriteLine("Modified Affine: " + cipher);
                        break;
                }
            }
        }

        static string Caesar(string cipher, int encodeFlag)
        {
            cipher = cipher.ToUpper();
            int shift = 0;
            string decoded="";
            /*Console.Write("Enter the shift, leave blank to try all: ");
            string temp;
            if ((temp = Console.ReadLine()) == "")
            {
                for (int i = 0; i <= 26; i++)
                {
                    foreach (char character in cipher)
                    {
                        if (i == 25)
                        {
                            i = 25;
                        }
                        decoded = decoded + shifter(character, i, encodeFlag);
                    }
                    decoded = decoded + "\n";
                }
            }
            else*/
            {
                shift = 3;//Convert.ToInt32(temp);
                foreach (char character in cipher)
                {
                    decoded = decoded + shifter(character, shift, encodeFlag);
                }
            }
            return decoded;
        }

        static string Atbash(string cipher)
        {
            cipher = cipher.ToUpper();
            string decoded = "";
            int shift;
            foreach (char c in cipher)
            {
                shift = -1* (25 - 2*(90 - c));
                decoded = decoded + shifter(c, shift, 0);
            }
            return decoded;
        }

        static string A1Z26(string cipher)
        {
            List<int> cipherInts = A1Z26_cleanse(cipher);
            string decoded = "";
            foreach (int i in cipherInts)
            {
                decoded = decoded + (char)(i+64);
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
                string temp  = "-" + m1 + "-";
                MatchCollection mc2 = Regex.Matches(temp, @"(?<=\-)(.*?)(?=\-)");
                foreach (Match m2 in mc2)
                {
                    temp = "";
                    foreach (char c in m2.ToString())
                    {
                        if (Char.IsPunctuation(c))
                        {
                            cipherints.Add(Convert.ToInt32(temp));
                            temp = (c - 64).ToString();
                        }
                        else
                            temp = temp + c;
                    }
                    cipherints.Add(Convert.ToInt32(temp));
                }
                cipherints.Add(-32);
            }
            return cipherints;
        }

        static string key_vigenere(string cipher, int encodeFlag)
        {
            Console.Write("Enter Key: ");
            string key = Console.ReadLine().ToUpper();
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
                decoded = decoded + shifter(cipher[i], key[(i-spaces)%key.Length]-65, encodeFlag);
            }
            return decoded;
        }

        static string mod_affine(string cipher, int encodeFlag)
        {
            cipher = cipher.ToUpper();
            cipher = " " + cipher + " ";
            MatchCollection mc = Regex.Matches(cipher, @"(?<=\ )(.*?)(?=\ )");
            string decoded = "";
            if (encodeFlag == 0)
            {
                return mod_affine_encode(mc);
            }
            else
            {
                List<List<char>> possibles = mod_affine_decode(mc);
                node start = new node(' ', possibles, 0);
                traverse(start, "");
                foreach (string word in mod_affine_word_list)
                {
                    Console.WriteLine(word);
                }
            }
            return decoded;

        }

        static string mod_affine_encode(MatchCollection mc)
        {
            string encoded = "";
            foreach (Match m in mc)
            {
                foreach (char c in m.ToString())
                {
                    int temp = ((c - 64) * m.Length) % 26;
                    if (temp == 0)
                    {
                        temp = 26;
                    }
                    encoded = encoded + (char)(temp + 64);
                }
            }
            return encoded;
        }

        static List<List<char>> mod_affine_decode(MatchCollection mc)
        {
            List<List<char>> possibles = new List<List<char>>();
            int count = 0;
            foreach (Match m in mc)
                {
                    Console.WriteLine(m.Length);
                    for(int i = 0; i <m.Length; i++)
                    {
                        possibles.Add(new List<char>());
                        char c = m.ToString()[i];
                        for (int a = 0; a < m.Length; a++ )
                        {
                            float canidate = ((c-64) + (a * 26)) / (float)m.Length;
                            if (canidate % 1 == 0)
                            {
                                possibles[count].Add((char)(canidate+64));
                            }
                        }
                        count++;
                    }
                    
                }
            return possibles;
        }

        static void traverse(node start, string decoded)
        {
            decoded = decoded + start.letter;
            if (start.nodes == null)
            {
                mod_affine_word_list.Add(decoded);
                return;
            }
            foreach(node next in start.nodes)
            {
                traverse(next, decoded);
            }
            return;
        }


        /*static List<int> vigenere_count(string cipher)
        {
            List<int> counts = new List<int>();
            for (int i = 1; i < cipher.Length; i++)
            {
                int count = 0;
                for (int j = 0; j+i < cipher.Length; j++)
                {
                    if (cipher[j] == cipher[j + i])
                    {
                        count++;
                    }
                }
                counts.Add(count);
            }
            return counts;
        }*/

        static char shifter(char c, int shift, int encodeFlag)
        {
            if (c == ' ' || Char.IsPunctuation(c) || Char.IsDigit(c))
            {
                return c;
            }
            int shifted;
            if (encodeFlag == 0)
            {
                shifted = c + shift;
            }
            else
            {
                shifted = c - shift;
            }
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

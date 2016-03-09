using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace CipherSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /*static void menu()
        {
            Console.WriteLine("1. Caesar\n2. Atbash\n3. A1Z26\n4. Vigenere w/ Key\n5. Modified Affine");
            Console.Write("Select ciphers in order: ");
            string input = Console.ReadLine();
            Console.Write("Enter cipher: ");
            string cipher = Console.ReadLine();
            foreach(char c in input)
            {
                switch (c)
                {
                    case '1':
                        cipher = Caesar.decode(cipher);
                        Console.WriteLine("Caesar: " + cipher);
                        break;
                    case '2':
                        cipher = Atbash.decode(cipher);
                        Console.WriteLine("Atbash: " + cipher);
                        break;
                    case '3':
                        cipher = A1Z26.decode(cipher);
                        Console.WriteLine("A1Z26: " + cipher);
                        break;
                    case '4':
                        cipher = Vigenere.decode(cipher);
                        Console.WriteLine("Vigenere: " + cipher);
                        break;
                    case '5':
                        cipher = ModAffine.decode(cipher);
                        Console.WriteLine("Modified Affine: " + cipher);
                        break;
                }
            }
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
    }
}

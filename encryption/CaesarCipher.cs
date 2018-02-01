using System;
using System.Text;

namespace Algorithms
{
    static class CaesarCipher
    {
        private const int LettersNumber = 26;
        private const int Shift = 3;
        private const string PlainText = "The quick brown fox jumps over the lazy dog.";

        public static void Test()
        {
            Console.WriteLine("Plain: {0}", PlainText);

            string encrypted = Encrypt(PlainText, Shift);
            Console.WriteLine("Encrypted: {0}", encrypted);

            string decrypted = Decrypt(encrypted, Shift);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        private static string Encrypt(string input, int shift)
        {
            StringBuilder resultSB = new StringBuilder();

            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    //отступ к началу буквенных символов
                    char offset = char.IsUpper(ch) ? 'A' : 'a';
                    
                    char shifted = (char)((ch - offset + shift) % LettersNumber + offset);

                    resultSB.Append(shifted);
                }
                else
                {
                    resultSB.Append(ch);
                }
            }

            return resultSB.ToString();
        }

        private static string Decrypt(string input, int shift)
        {
            return Encrypt(input, LettersNumber - shift);
        }        
    }
}

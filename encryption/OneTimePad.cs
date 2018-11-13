using System;
using System.Text;

namespace Algorithms
{
    static class OneTimePad
    {
        private const string Alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private const string Text = "violet";

        public static void Test()
        {
            string key = GetRandomKey(Text.Length);

            byte[] textBytes = Encoding.UTF8.GetBytes(Text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);            

            byte[] encryptedBytes = PerformXOR(textBytes, keyBytes);
            byte[] decryptedBytes = PerformXOR(encryptedBytes, keyBytes);

            PrintBytes("TEXT", Text, textBytes);
            PrintBytes("KEY", key, keyBytes);
            PrintBytes("ENCRYPTED", Convert.ToBase64String(encryptedBytes) + " (base64)", encryptedBytes);
            PrintBytes("DECRYPTED", Encoding.UTF8.GetString(decryptedBytes), decryptedBytes);
        }

        public static string GetRandomKey(int length)
        {
            char[] result = new char[length];

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(0, Alphanumeric.Length);
                result[i] = Alphanumeric[randomIndex];
            }

            return new string(result);
        }

        private static byte[] PerformXOR(byte[] textBytes, byte[] keyBytes)
        {
            byte[] resultBytes = new byte[textBytes.Length];

            for (int i = 0; i < textBytes.Length; i++)
            {
                resultBytes[i] = (byte)(textBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return resultBytes;
        }

        private static void PrintBytes(string name, string content, byte[] bytes)
        {
            StringBuilder bytesSB = new StringBuilder();
            StringBuilder bitsSB = new StringBuilder();

            foreach (byte b in bytes)
            {
                bytesSB.Append(b.ToString()).Append(" ");

                bitsSB.Append(Convert.ToString(b, 2).PadLeft(8, '0')).Append(" ");
            }

            Console.WriteLine(name);
            Console.WriteLine(content);
            Console.WriteLine(bytesSB.ToString());
            Console.WriteLine(bitsSB.ToString());
            Console.WriteLine();
        }
    }
}

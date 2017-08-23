using System;

namespace Algorithms
{
    static class Factorial
    {
        public static void Test()
        {
            for (int n = 0; n <= 12; n++)
            {
                Console.WriteLine("n = {0}", n);
                Console.WriteLine(Iteration(n));
                Console.WriteLine(Recursion(n));
                Console.WriteLine();
            }
        }

        private static int Iteration(int n)
        {
            int result = 1;

            for (; n > 0; n--)
            {
                result *= n;
            }

            return result;
        }

        private static int Recursion(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Recursion(n - 1);
        }
    }
}

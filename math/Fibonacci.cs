using System;

namespace Algorithms
{
    static class Fibonacci
    {
        public static void Test()
        {
            for (uint n = 0; n <= 12; n++)
            {
                Console.WriteLine("n = {0}", n);
                Console.WriteLine(Recursion(n));
                Console.WriteLine(Dynamic(n));
                Console.WriteLine(Short(n));
                Console.WriteLine();
            }
        }

        private static uint Recursion(uint n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Recursion(n - 1) + Recursion(n - 2);
        }

        private static uint Dynamic(uint n)
        {
            if (n <= 1)
            {
                return n;
            }

            uint[] result = new uint[n + 1];
            result[0] = 0;
            result[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result[n];
        }

        private static uint Short(uint n)
        {
            if (n <= 1)
            {
                return n;
            }

            uint fib1 = 0;
            uint fib2 = 1;
            uint sum = 0;

            for (int i = 2; i <= n; i++)
            {
                sum = fib1 + fib2;
                fib1 = fib2;
                fib2 = sum;
            }

            return sum;
        }
    }
}
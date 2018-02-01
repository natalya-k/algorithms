namespace Algorithms
{
    static class BinarySearch
    {
        public static int? Search(int[] array, int target)
        {
            int begin = 0;
            int end = array.Length - 1;

            int guess;

            while (end >= begin)
            {
                //guess = (begin + end) / 2;

                //этот вариант предотвращает переполнение стека при больших значениях begin и end
                guess = begin + (end - begin) / 2;  

                if (array[guess] == target)
                {
                    return guess;
                }

                if (array[guess] > target)
                {
                    end = guess - 1;
                }
                else
                {
                    begin = guess + 1;
                }
            }

            return null;
        }
    }
}

namespace Algorithms
{
    static class SimpleSort
    {
        static void SelectionSort(int[] array)
        {
            int min;
            int temp;

            for (int begin = 0; begin < array.Length - 1; ++begin)
            {
                min = begin;

                for (int i = min + 1; i < array.Length; i++)
                {
                    if (array[i] < array[min])
                    {
                        min = i;
                    }
                }

                temp = array[begin];
                array[begin] = array[min];
                array[min] = temp;
            }
        }

        static void InsertionSort(int[] array)
        {
            int current;
            int i;

            for (int begin = 1; begin < array.Length; ++begin)
            {
                current = array[begin];

                i = begin - 1;

                while (i >= 0 && array[i] > current)
                {
                    array[i + 1] = array[i];
                    i--;
                }

                array[i + 1] = current;
            }
        }

        static void BubbleSort(int[] array)
        {
            for (int end = array.Length - 1; end > 0; --end)
            {
                for (int i = 0; i < end; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
    }
}

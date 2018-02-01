namespace Algorithms
{
    static class SimpleSort
    {
        public static void SelectionSort(int[] array)
        {
            int begin, min, i;
            int temp;

            for (begin = 0; begin < array.Length - 1; begin++)
            {
                min = begin;

                for (i = min + 1; i < array.Length; i++)
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

        public static void InsertionSort(int[] array)
        {
            int current;
            int begin, i;

            for (begin = 1; begin < array.Length; begin++)
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

        public static void BubbleSort(int[] array)
        {
            int n = array.Length, i;
            bool swapped;
            int temp;

            do
            {
                swapped = false;

                for (i = 1; i < n; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;

                        swapped = true;
                    }
                }

                n--;

            } while (swapped);
        }
    }
}

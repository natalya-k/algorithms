namespace Algorithms
{
    public static class HeapSort
    {
        public static void Run(int[] array)
        {
            //индекс последнего узла, у которого есть хотя бы один потомок
            int begin = array.Length / 2 - 1;

            for (int i = begin; i >= 0; i--)
            {
                Heapify(array, array.Length, i);
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                Swap(array, 0, i);

                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int length, int current)
        {
            int max = current;
            int left = 2 * current + 1;
            int right = left + 1;

            if (left < length && array[left] > array[max])
            {
                max = left;
            }

            if (right < length && array[right] > array[max])
            {
                max = right;
            }

            if (current != max)
            {
                Swap(array, current, max);

                //перестраивание получившегося поддерева
                Heapify(array, length, max);
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

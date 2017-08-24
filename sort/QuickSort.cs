namespace Algorithms
{
    static class QuickSort
    {
        public static void Run(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = 0;

                Divide(array, left, right, ref pivot);

                Sort(array, left, pivot - 1);
                Sort(array, pivot + 1, right);
            }
        }

        private static void Divide(int[] array, int left, int right, ref int pivot)
        {
            //самый правый элемент становится опорным
            pivot = right;

            int i, k = left;

            for (i = left; i < pivot; i++)
            {
                //все элементы, которые меньше или равны опорному,
                //перемещаются в левую часть

                if (array[i] <= array[pivot])
                {
                    Swap(array, k, i);
                    k++;
                }
            }

            //опорный элемент встает на свое место

            Swap(array, k, pivot);
            pivot = k;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

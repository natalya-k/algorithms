namespace Algorithms
{
    static class MergeSort
    {
        public static void Run(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                //int middle = (left + right) / 2;

                //этот вариант предотвращает переполнение стека при больших значениях left и right
                int middle = left + (right - left) / 2;

                Sort(array, left, middle);
                Sort(array, middle + 1, right);

                Merge(array, left, middle, right);
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int leftLength = middle - left + 1;
            int rightLength = right - middle;

            int[] leftHalf = new int[leftLength];
            int[] rightHalf = new int[rightLength];

            //копирование элементов во временные массивы

            int i = 0, j = 0, k = left;            

            while (k <= middle)
            {
                leftHalf[i] = array[k];
                i++;
                k++;
            }

            while (k <= right)
            {
                rightHalf[j] = array[k];
                j++;
                k++;
            }

            //слияние элементов в отсортированном виде

            i = j = 0;
            k = left;            

            while (i < leftHalf.Length && j < rightHalf.Length)
            {
                if (leftHalf[i] < rightHalf[j])
                {
                    array[k] = leftHalf[i];
                    i++;
                }
                else
                {
                    array[k] = rightHalf[j];
                    j++;
                }

                k++;
            }

            //копирование оставшейся части элементов

            while (i < leftHalf.Length)
            {
                array[k] = leftHalf[i];
                i++;
                k++;
            }

            while (j < rightHalf.Length)
            {
                array[k] = rightHalf[j];
                j++;
                k++;
            }
        }
    }
}

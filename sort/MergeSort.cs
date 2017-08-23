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
                int middle = left + (right - left) / 2; //этот вариант предотвращает переполнение стека при больших значениях left, right

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

            int i, j, k = left;

            //tbd переделать for в while?

            for (i = 0; k <= middle; i++, k++)
            {
                leftHalf[i] = array[k];
            }

            for (j = 0; k <= right; j++, k++)
            {
                rightHalf[j] = array[k];
            }
            
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

            for (; i < leftHalf.Length; i++, k++)
            {
                array[k] = leftHalf[i];
            }

            for (; j < rightHalf.Length; j++, k++)
            {
                array[k] = rightHalf[j];
            }
        }
    }
}
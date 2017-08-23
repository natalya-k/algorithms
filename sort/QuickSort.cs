using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int k = left;

            for (int i = left; i < right; i++)
            {
                if (array[i] <= array[right])
                {
                    Swap(array, k, i);
                    k++;
                }
            }

            Swap(array, k, right);

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
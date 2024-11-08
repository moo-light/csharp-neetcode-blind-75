using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting_algorithm
{
    internal class MergeSort : ISortable
    {
        public static int[] Sort(int[] arr)
        {
            int n = arr.Length - 1;

            DoMergeSort(arr, 0, n);

            return arr;
        }

        private static void DoMergeSort(int[] arr, int l, int r)
        {
            if (l == r) return;
            int mid = (int)Math.Floor((double)(l + r) / 2);
            DoMergeSort(arr, l, mid);
            DoMergeSort(arr, mid + 1, r);
            int[] temp = new int[r - l + 1]; // create a new array to merge with arr
            int i = l, j = mid + 1, k = 0;
            while (i <= mid && j <= r)
            {
                int next;
                if (arr[i] < arr[j]) next = arr[i++];
                else next = arr[j++];
                temp[k++] = next; 
            }
            // take the remainder
            while (i <= mid) temp[k++] = arr[i++];
            while (j <= r) temp[k++] = arr[j++];
            // merge to arr
            for (i = 0; i < k; i++) arr[l + i] = temp[i];
        }
    }
}

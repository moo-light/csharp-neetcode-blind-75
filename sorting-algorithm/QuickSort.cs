using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting_algorithm
{
    internal class QuickSort : ISortable
    {
        public static int[] Sort(int[] arr)
        {
            int n = arr.Length - 1;
            DoQuickSort2(arr, 0, n);
            return arr;
        }
        // move pivot to the middle
        // left is smaller than pivot 
        // right is larger than pivot
        private static void DoQuickSort(int[] arr, int l, int r)
        {
            if (l == r) return;
            int mid = l + (r - l) / 2;
            int pivot = arr[mid];
            int[] L = new int[r - l], R = new int[r - l];
            int m = 0, n = 0;
            int i;
            // Create Left and Right
            for (i = l; i <= r; i++)
            {
                if (i == mid) continue;
                if (arr[i] < pivot)
                    L[m++] = arr[i];
                else
                    R[n++] = arr[i];
            }

            int j = l;
            // assign Left and right to arr
            for (i = 0; i < m; i++)
            {
                arr[j++] = L[i];
            }
            int pivotIndex = j;
            arr[j++] = pivot;
            for (i = 0; i < n; i++)
            {
                arr[j++] = R[i];
            }
            //recursion
            DoQuickSort(arr, l, pivotIndex);
            DoQuickSort(arr, pivotIndex + 1, r);
        }
        private static void DoQuickSort2(int[] arr, int l, int r)
        {
            if (l >= r) return;
            int pivot = arr[r];
            int i = l-1;
            pivot.Print("Pivot: ");
            arr.PrintArr(l, r);

            for (int j = l; j < r; j++)
            {
                //right need to be larger than pivot
                if (arr[j] < pivot)
                {
                    i++;
                    //swap
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }
            int pindex = i + 1;

            //swap i+1 with high
            (arr[pindex], arr[r]) = (arr[r], arr[pindex]);
            //recursion
            DoQuickSort2(arr, l, pindex - 1);
            DoQuickSort2(arr, pindex + 1, r);
        }
        
    }


}

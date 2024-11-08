using sorting_algorithm;

int[][] arrs = [
    //[4, 3, 2, 1], 
    [3123, 123, 312, 4, 34, 435, 4364, 36436, 56, 567, 7, 43]];

foreach (var item in arrs)
{
    int[] arr = new int[item.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = item[i];
    }

    item.Print("Current:");
    //MergeSort.Sort(arr).Print("Merge Sort: ");
    QuickSort.Sort(arr).Print("Quick Sort: ");

    Console.WriteLine();
}

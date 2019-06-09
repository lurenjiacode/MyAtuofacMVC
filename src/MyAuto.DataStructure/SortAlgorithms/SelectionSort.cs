

namespace MyAuto.DataStructure.SortAlgorithms
{
    using System;
    using System.Collections.Generic;

    public partial class Sort
    {
        public void SelectionSort(List<int> arr)
        {
            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < arr.Count - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < arr.Count; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }

        public void SelectionSort2(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[j] < arr[min_idx])
                        min_idx = j;
                }
                Console.WriteLine("第{0}趟，后面的最小值：{1}", i, min_idx);

                // Swap the found minimum element with the first element
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;

            }
        }
    }
}

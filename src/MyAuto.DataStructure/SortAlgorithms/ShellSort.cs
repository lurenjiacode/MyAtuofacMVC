﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.SortAlgorithms
{
    public partial class Sort
    {
        public List<int> ShellSort(List<int> list)
        {
            List<int> arr = new List<int>();
            arr = list;


            int n = list.Count;

            // Start with a big gap,  
            // then reduce the gap 
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already 
                // in gapped order keep adding one more element 
                // until the entire array is gap sorted 
                for (int i = gap; i < n; i += 1)
                {
                    // add a[i] to the elements that have 
                    // been gap sorted save a[i] in temp and 
                    // make a hole at position i 
                    int temp = arr[i];

                    // shift earlier gap-sorted elements up until 
                    // the correct location for a[i] is found 
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        arr[j] = arr[j - gap];

                    // put temp (the original a[i])  
                    // in its correct location 
                    arr[j] = temp;
                }
            }




            return arr;
        }

        public void ShellSort1(List<int> list)
        {
            int num = list.Count;
            for (int gap = num / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < num; i += 1)
                {
                    int temp = list[i];
                    int j;
                    for (j = i; j >= gap && list[j - gap] > temp; j -= gap)
                        list[j] = list[j - gap];
                    list[j] = temp;
                }
            }
        }
    }
}

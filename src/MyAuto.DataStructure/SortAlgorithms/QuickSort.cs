using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.SortAlgorithms
{
    public partial class Sort
    {
        public List<int> QuickSort(List<int> list)
        {
            int temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j + 1] < list[j])
                    {
                        temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
    }
}

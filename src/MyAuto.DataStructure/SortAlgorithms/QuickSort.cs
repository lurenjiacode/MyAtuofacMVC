using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.SortAlgorithms
{
    public partial class Sort
    {
        public void QuickSort2(List<int> num, int left,int right)
        {

             if (left >= right)
                return;

            int key = num[left];
            int i = left;
            int j = right;

            while (i < j)
            {
                while (i < j && key < num[j])
                    j--;
                if (i >= j)
                {
                    num[i] = key;
                    break;
                }
                num[i] = num[j];

                while (i < j && key >= num[i])
                    i++;
                if (i >= j)
                {
                    num[i] = key;
                    break;
                }
                num[j] = num[i];
            }
            num[i] = key;

            QuickSort(num, left, i - 1);
            QuickSort(num, i + 1, right);

        }

        public void QuickSort(List<int> list, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int i= start;
            int j= end;
            int key = list[i];

            while (i<j)
            {
                while (list[j] >= key && i < j)
                    j--;

                if (i < j)
                {
                    int temp = 0;
                    temp = list[j];
                    list[j] = list[i];
                    list[i] = temp;
                }


                while (list[i] <= key&& i<j)
                    i++;

                if ( i < j)
                {
                    int temp = 0;
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }

            }

            QuickSort(list,start,i-1);

            QuickSort(list, i + 1, end);

        }
    }
}

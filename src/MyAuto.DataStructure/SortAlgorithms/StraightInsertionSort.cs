using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.SortAlgorithms
{
    public partial class Sort
    {
        //直接插入排序
        public void StraightInsertionSort2(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int j = 0;
                int temp = list[i];
                for (j = i - 1; j > 0 && temp < list[j]; j--)
                    list[j + 1] = list[i];
                list[j + 1] = temp;
            }
        }
        public void StraightInsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)  //首选取出第一个数（3）作为一个有序的数组，然后遍历传入数组"3"之后的每一个数
            {
                int j;
                int key = list[i];
                for (j = i - 1; j >= 0; j--) //因为取出来的数是一个有序数组，排序是从小往大递增的，所以插入新的数字的时候只需要
                {
                    if (list[j] < key)       //==>倒序比较，假如比数组的最后一个数字大，前面的就不需要再比较了，这里就是最先比较的
                    {
                        break;              //最大数就是list[j]
                    }
                    else
                    {
                        list[j + 1] = list[j]; //假如待插入数字不比最大的一个数字大，就依次跟前面的数字比较，同时把比较过的数字
                    }                          //位置依次右移
                }
                list[j + 1] = key;              //最后找到合适的位置插入数组
            }
        }
        public void InsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int j = 0;
                j = i - 1;
                int temp = list[i];
                while (j >= 0 && temp < list[j])
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = temp;
            }
        }
        public List<int> InsertSort(List<int> list)
        {
            List<int> arr = new List<int>();
            arr = list;

            for (int i = 0; i < arr.Count; i++)
            {
                int j = 0;
                int temp = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j]; //向右移动
                    j = j - 1;
                }
                arr[j + 1] = temp;//将值取出放到左边
            }

            return arr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.SortAlgorithms
{
    public partial class Sort
    {
        //升序
        public List<int> BubbleSort(List<int> list)
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
        public List<int> BubbleSortPrint(List<int> list)
        {
            int temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("开始大大大大大大大大循环：{0},内循环:{1}", i, list.Count - 1 - i);
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    Console.WriteLine("开始小循环：{0}", j);
                    if (list[j + 1] < list[j])
                    {
                        temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                        Console.WriteLine("{0} SWAP {1} 做交换,列表 ： {2}", list[j], list[j + 1], PrintList(list));
                    }
                    else
                    {
                        Console.WriteLine("{0} SWAP {1} 不做交换,列表 ： {2}", list[j], list[j + 1], PrintList(list));
                    }
                }
            }
            return list;
        }
        public string PrintList(List<int> list)
        {
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str += list[i].ToString() + "    ";
            }
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.SortAlgorithms
{
    public class NumData
    {
        /// <summary>
        /// 返回在指定范围内的一组无序的任意整数（随机数列表）。
        /// </summary>
        /// <param name="minValue">返回的随机数字包含下限。</param>
        /// <param name="maxValue">返回随机数的不含上限。 maxValue必须大于或等于minValue。</param>
        /// <param name="size">生成随机数的个数</param>
        /// 异常：minValue 大于 maxValue。
        /// <returns>返回随机数列表</returns>
        public static List<int> RandomInt(int minValue, int maxValue, int size)
        {
            Random rd = new Random();
            List<int> randomnum = new List<int>();
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("min值过大");
            for (int i = 0; i < size; i++)
            {
                randomnum.Add(rd.Next(minValue, maxValue));
            }
            return randomnum;
        }
    }
}

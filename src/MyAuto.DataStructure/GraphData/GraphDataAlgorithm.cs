using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.GraphData
{
    public class GraphDataAlgorithm
    {
        private int[,] _graphDataValue { get; set; }


        /// <summary>
        /// 构造图
        /// </summary>
        /// <param name="graphData">已经赋值完成的图</param>
        public GraphDataAlgorithm()
        {
        }
        public GraphDataAlgorithm(int[,] graphData)
        {
            this._graphDataValue = graphData;
        }

        public int[,] AdjacencyMatrix { get; set; }

        static int row = 7;
        //ArrayList S = new ArrayList(row);//S储存确定最短路径的顶点的下标
        //ArrayList U = new ArrayList(row);//U中存储尚未确定路径的顶点的下标


        /// <summary>
        /// VertexIDList储存确定最短路径的顶点ID
        /// </summary>
        ArrayList CertIDList = new ArrayList();

        /// <summary>
        /// 中储存尚未确定路径的顶点ID
        /// </summary>
        ArrayList UnCertIDList = new ArrayList();

        int[] distance = new int[7];//用以每次查询存放数据
        int[] prev = new int[7];//用以存储前一个最近顶点的下标
        bool[] Isfor = new bool[7] { false, false, false, false, false, false, false };

        /// <summary>
        /// Dijkstra 算法的实现部分
        /// </summary>
        /// <param name="start">起点(顶点id)</param>
        public void DijkstraFindWay(int start)
        {
            var graph = this.AdjacencyMatrix;
            CertIDList.Add(start);
            Isfor[start] = true;
            for (int i = 0; i < row; i++)
            {
                if (i != start)
                    UnCertIDList.Add(i);
            }
            for (int i = 0; i < row; i++)
            {
                distance[i] = AdjacencyMatrix[start, i];
                prev[i] = 0;
            }
            int Count = UnCertIDList.Count;
            while (Count > 0)
            {
                int min_index = (int)UnCertIDList[0];//假设U中第一个数存储的是最小的数的下标
                foreach (int r in UnCertIDList)
                {
                    if (distance[r] < distance[min_index] && !Isfor[r])
                        min_index = r;
                }
                CertIDList.Add(min_index);//S加入这个最近的点
                Isfor[min_index] = true;
                UnCertIDList.Remove(min_index);//U中移除这个点；
                foreach (int r in UnCertIDList)
                {
                    //查找下一行邻接矩阵，如何距离和上一个起点的距离和与数组存储的相比比较小，就更改新的距离和起始点,再比对新的起点到各边的距离
                    if (distance[r] > distance[min_index] + AdjacencyMatrix[min_index, r])
                    {
                        distance[r] = distance[min_index] + AdjacencyMatrix[min_index, r];
                        prev[r] = min_index;
                    }
                    else
                    {
                        distance[r] = distance[r];
                    }
                }
                Count = UnCertIDList.Count;
            }
        }


        public void display(int start)
        {
            for (int i = 0; i < row; i++)
            {
                if (i == 6)
                {
                    Console.Write("V{1}到V{0}的最短路径为→V{1}", i, start);
                    int prePoint = prev[i];
                    string s = "";
                    StringBuilder sb = new StringBuilder(10);
                    while (prePoint > 0)
                    {
                        s = (prePoint + 1) + s;
                        prePoint = prev[prePoint];
                    }
                    for (int j = 0; j < s.Length; j++)
                    {
                        sb.Append("-Va").Append(s[j]);
                    }
                    Console.Write(sb.ToString());
                    Console.Write("-Vb{0}", i);
                    Console.WriteLine(":{0}", distance[i]);
                }
            }
        }
        //弗洛伊德(Floyd)算法 主要是用于计算图中所有顶点对之间的最短距离长度的算法，
        //如果是要求某一个特定点到图中所有顶点之间的最短距离可以用Dijkstra(迪杰斯特拉)算法来求。

        //无向图中任意两点之间的所有路径的C#实现
        public Stack stack = new Stack();/*临时保存路径节点的栈*/
        public ArrayList sers = new ArrayList();/*存储路径的集合*/

        public void FindAToBAllWay(int start, int end)
        {
            int[] a = new int[7];
        }


        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.GraphData
{
    class UndirectedGraphData
    {
        /// <summary>
        /// 图的顶点数
        /// </summary>
        public int VertexCount { get; set; }

        /// <summary>
        /// 最大顶点数
        /// </summary>
        public int MaxVertexCount { get; set; }

        /// <summary>
        /// 节点计数器
        /// </summary>
        private int num = 0;

        /// <summary>
        /// 存储图的邻接矩阵
        /// 邻接矩阵 : adjacency matrix
        /// 无法到达的节点边为9999
        /// </summary>
        public int[,] AdjacencyMatrix { get; set; }

        /// <summary>
        /// 顶点字典（键和值的集合）
        /// </summary>
        readonly Dictionary<string, Vertex> Vertexs = new Dictionary<string, Vertex>();

        public UndirectedGraphData(int vertexcount)
        {
            this.MaxVertexCount = vertexcount;
            InitUndirectedGraphData(MaxVertexCount);
        }

        /// <summary>
        /// 仅限控制台
        /// </summary>
        public void Show()
        {
            int vertexcount = this.VertexCount;
            if (vertexcount == 0)
            {
                Console.WriteLine("顶点为空的图");
                throw new ArgumentNullException(vertexcount.ToString(), "顶点数量为0");
            }
            
            Console.WriteLine("开始打印邻接矩阵...");
            for (int i = 0; i < vertexcount; i++)
            {
                for (int j = 0; j < vertexcount; j++)
                {
                    Console.Write(AdjacencyMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("打印完成。");
        }

        /// <summary>
        /// 初始化无向图
        /// </summary>
        /// <param name="vertexcount">最大顶点数</param>
        private void InitUndirectedGraphData(int vertexcount)
        {
            //初始化邻接矩阵和顶点数组
            AdjacencyMatrix = new int[vertexcount, vertexcount];

            this.VertexCount = vertexcount;
            //将代表图的邻接矩阵的顶点全初始化为9999
            for (int i = 0; i < vertexcount; i++)
            {
                for (int j = 0; j < vertexcount; j++)
                {
                    AdjacencyMatrix[i, j] = 9999;
                }
            } 
        }



        /// <summary>
        /// 向图中添加节点
        /// </summary>
        /// <param name="nodename"></param>
        public void AddNode(string nodename)
        {
            if (num + 1 > this.VertexCount)
            {
                throw new ArgumentNullException("添加顶点：" + nodename + "失败，已经到达节点上限！");
            }
            if (Vertexs.ContainsKey(nodename))
            {
                throw new ArgumentNullException("添加顶点：" + nodename + "失败，不能重复添加！");
            }
            var node = new Vertex(num + 1, nodename);
            Vertexs.Add(nodename, node);
            AdjacencyMatrix[num, num] = 0;
            this.num++;
        }
        public void AddNodePrt(string nodename)
        {
            if (num + 1 > this.VertexCount)
            {
                Console.WriteLine("添加顶点：" + nodename + "失败");
                Console.WriteLine(nodename + "节点不能添加，已经到达节点上限！");
                return;
            }
            if (Vertexs.ContainsKey(nodename))
            {
                Console.WriteLine("添加顶点：" + nodename + "失败");
                Console.WriteLine("已经有该节点，不能重复添加！");
                return;
            }
            var node = new Vertex(num + 1, nodename);
            Vertexs.Add(nodename, node);
            AdjacencyMatrix[num, num] = 0;

            this.num++;
            Console.WriteLine("添加顶点：" + nodename + "成功");
        }

        /// <summary>
        /// 在无向图的顶点X,Y之间添加权值为weight的边
        /// 无向图
        /// Undirected Graph
        /// </summary>
        /// <param name="nodeX">顶点X</param>
        /// <param name="nodeY">顶点Y</param>
        /// <param name="weight">权值</param>
        public void AddUndirectedGraphEdge(string nodeXname, string nodeYname, int weight)
        {
            if (!Vertexs.ContainsKey(nodeXname))
            {
                throw new ArgumentException("顶点：" + nodeXname + "未添加！");
            }
            if (!Vertexs.ContainsKey(nodeYname))
            {
                throw new ArgumentException("顶点：" + nodeYname + "未添加！");
            }

            Vertex x = Vertexs[nodeXname];
            Vertex y = Vertexs[nodeYname];

            AdjacencyMatrix[x.VertexId - 1, y.VertexId - 1] = weight;
            AdjacencyMatrix[y.VertexId - 1, x.VertexId - 1] = weight;
        }
        public void AddUndirectedGraphEdgePrt(string nodeXname, string nodeYname, int weight)
        {
            if (!Vertexs.ContainsKey(nodeXname))
            {
                Console.WriteLine("未添加该节点！");
                return;
            }
            if (!Vertexs.ContainsKey(nodeYname))
            {
                Console.WriteLine("未添加该节点！");
                return;
            }

            Vertex x = Vertexs[nodeXname];
            Vertex y = Vertexs[nodeYname];

            AdjacencyMatrix[x.VertexId - 1, y.VertexId - 1] = weight;
            AdjacencyMatrix[y.VertexId - 1, x.VertexId - 1] = weight;
        }




        /// <summary>
        /// VertexIDList储存确定最短路径的顶点ID
        /// </summary>
        readonly ArrayList CertIDList = new ArrayList();
        /// <summary>
        /// 中储存尚未确定路径的顶点ID
        /// </summary>
        readonly ArrayList UnCertIDList = new ArrayList();

        readonly int[] distance = new int[7];//用以每次查询存放数据
        readonly int[] prev = new int[7];//用以存储前一个最近顶点的下标
        readonly bool[] Isfor = new bool[7] { false, false, false, false, false, false, false };


        /// <summary>
        /// Dijkstra 算法的实现部分
        /// 迪杰斯特拉算法
        /// </summary>
        /// <param name="startVertex">起点(顶点id)</param>
        public void DijkstraFindWay(string startVertex)
        {
            int startid = Vertexs[startVertex].VertexId;

            CertIDList.Add(startid);
            Isfor[startid] = true;

            for (int i = 0; i < VertexCount; i++)
            {
                if (i != startid)
                    UnCertIDList.Add(i);
            }
            for (int i = 0; i < VertexCount; i++)
            {
                distance[i] = AdjacencyMatrix[startid, i];
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
                        this.distance[r] = distance[r];
                    }
                }
                Count = UnCertIDList.Count;
            }
        }

        public void ShowWay(string startVertex)
        {
            int startid = Vertexs[startVertex].VertexId;

            for (int i = 0; i < VertexCount; i++)
            {
                if (i == 6)
                {
                    Console.Write("V{1}到V{0}的最短路径为→V{1}", i, startid);
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
    }
}

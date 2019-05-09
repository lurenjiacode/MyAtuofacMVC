using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.GraphData
{
    public class GraphDataHandler
    {
        /// <summary>
        /// 初始化图
        /// </summary>
        public void InitGraph()
        {
            Console.WriteLine("初始化无向图");
            UndirectedGraphData myGraph = new UndirectedGraphData(7);
            Console.WriteLine("开始打印初始化的无向图...");
            Console.WriteLine("最多顶点数量：{0}", myGraph.MaxVertexCount);
            myGraph.Show();
            Console.WriteLine("结束初始化");

            myGraph.AddNode("V0");
            myGraph.AddNode("V1");
            myGraph.AddNode("V2");
            myGraph.AddNode("V3");
            myGraph.AddNode("V4");
            myGraph.AddNode("V5");
            myGraph.AddNode("V6");

            Console.WriteLine("顶点添加结束。");

            myGraph.AddUndirectedGraphEdge("V0", "V1", 3);
            myGraph.AddUndirectedGraphEdge("V0", "V2", 7);
            myGraph.AddUndirectedGraphEdge("V0", "V3", 5);
            myGraph.AddUndirectedGraphEdge("V1", "V2", 2);
            myGraph.AddUndirectedGraphEdge("V1", "V4", 6);
            myGraph.AddUndirectedGraphEdge("V2", "V3", 3);
            myGraph.AddUndirectedGraphEdge("V2", "V4", 3);
            myGraph.AddUndirectedGraphEdge("V3", "V5", 2);
            myGraph.AddUndirectedGraphEdge("V3", "V6", 8);
            myGraph.AddUndirectedGraphEdge("V4", "V6", 2);
            myGraph.AddUndirectedGraphEdge("V5", "V6", 2);

            Console.WriteLine("编添加结束。");
            myGraph.Show();
            Console.WriteLine("赋值打印：");

            //GraphDataAlgorithm graphAlgorithm = new GraphDataAlgorithm(myGraph.adjmatrix);
            //graphAlgorithm.Metro = myGraph.adjmatrix;

            myGraph.DijkstraFindWay("V0");
            myGraph.ShowWay("V0");

            //myGraph.TopSort();
            Console.ReadKey();
        }
    }
}

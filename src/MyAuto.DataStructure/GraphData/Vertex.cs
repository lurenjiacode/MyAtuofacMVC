using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.GraphData
{
    /// <summary>
    /// 顶点（Vertex）类
    /// </summary>
    public class Vertex
    {

        /// <summary>
        /// 顶点Id
        /// </summary>
        public int VertexId { get; set; }
        /// <summary>
        /// 顶点名称
        /// </summary>
        public string VertexName { get; set; }
        /// <summary>
        /// 顶点数据
        /// </summary>
        public string Data { get; set; }

        public Vertex()
        {
        }

        /// <summary>
        /// 顶点信息
        /// </summary>
        /// <param name="id">顶点id</param>
        /// <param name="name">顶点名称</param>
        public Vertex(int id, string name)
        {
            this.VertexId = id;
            this.VertexName = name;
            this.Data = "节点id:" + id + "节点名称" + name;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.GraphData
{
    public class VertexInfo
    {
        public int VertexId { get; set; }
        public string VertexName { get; set; }
        public string Data { get; set; }

        public VertexInfo(int id, string name)
        {
            this.VertexId = id;
            this.VertexName = name;
            this.Data = "节点id:" + id + "节点名称" + name;
        }

    }
}

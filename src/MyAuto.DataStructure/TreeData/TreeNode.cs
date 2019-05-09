using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.TreeData
{
    public class TreeNode
    {
        public int TreeNodeId { get; set; }
        public string TreeNodeName { get; set; }
        public string TreeNodeDate { get; set; }

        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

    }
}

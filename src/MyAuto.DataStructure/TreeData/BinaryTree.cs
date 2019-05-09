using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.DataStructure.TreeData
{
    public class BinaryTree
    {
        //头引用
        public TreeNode Head { get; set; }

        public BinaryTree()
        {
            Head = null;
        }
        public BinaryTree(string val)
        {
            //TreeNode p = new TreeNode(val);
            //Head = p;
        }
    }
}

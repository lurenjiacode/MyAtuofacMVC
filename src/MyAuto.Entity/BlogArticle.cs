using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Entity
{
    public class BlogArticle
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Creator { get; set; }
        public string BlogContent { get; set; }
        public DateTime BlogCreateTime { get; set; }
    }
}

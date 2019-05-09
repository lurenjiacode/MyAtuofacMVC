using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Entity
{
    public class Movie
    {
        public int MovID { get; set; }
        public string MovName { get; set; }
        public string Classify { get; set; }
        public string Performer { get; set; }
        public string CollectionNum { get; set; }
        public string FileName { get; set; }
        public string ImgPath { get; set; }
        public DateTime MovieCreateTime { get; set; }
    }
}

using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Elasticsearch
{
    [ElasticsearchType(Name = "articles")]
    public class Articles
    {
        public int Id { get; set; }

        [Text(Analyzer = "ik_smart")]
        public string Title { get; set; }

        public string ItemUrl { get; set; }
        [Text(Analyzer = "ik_smart")]
        public string Sumary { get; set; }
        [Text(Analyzer = "ik_smart", Fielddata = true)]
        public string Author { get; set; }

        public string PubDate { get; set; }
        [Text(Analyzer = "ik_smart")]
        public string Content { get; set; }

    }
}

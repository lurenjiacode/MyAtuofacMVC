using Elasticsearch.Net;
using Nest;
using Nest.JsonNetSerializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Elasticsearch
{
    public class ElasticSearchHelper
    {
        public static readonly ElasticSearchHelper Intance = new ElasticSearchHelper();
        //private ElasticConnection Client;
        private ElasticSearchHelper()
        {
            var node = new Uri("http://192.168.56.1:9200");
            var setting = new ConnectionSettings(node);
            var client = new ElasticClient(setting);

            //var nodes = new Uri[]
            //{
            //    new Uri("http://myserver1:9200"),
            //    new Uri("http://myserver2:9200"),
            //    new Uri("http://myserver3:9200")
            //};
            //var pool = new StaticConnectionPool(nodes);
            //var settings = new ConnectionSettings(pool);
            //var clients = new ElasticClient(settings);
        }

        
       


    }
}

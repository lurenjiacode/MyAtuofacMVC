using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Elasticsearch
{
    public class ESHelper
    {
        public void Helper()
        {
            var node = new Uri("http://myserver:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);

            var settings2 = new ConnectionSettings()
                .DefaultIndex("defaultindex");

            //创建索引
            var descriptor = new CreateIndexDescriptor("db_student")
                .Settings(s => s.NumberOfShards(5).NumberOfReplicas(1));
            client.CreateIndex(descriptor);


            //删除索引
            var descriptor2= new DeleteIndexDescriptor("db_student").Index("db_student");
            client.DeleteIndex(descriptor2);

            //删除指定索引所在节点下的所有索引
            var descriptor3 = new DeleteIndexDescriptor("db_student").AllIndices();


            var descriptor4 = new CreateIndexDescriptor("db_student")
                .Settings(s => s.NumberOfShards(5).NumberOfReplicas(1))
                .Mappings(ms => ms
                .Map<Student>(m => m.AutoMap()));

            client.CreateIndex(descriptor4);

        }

    }
}

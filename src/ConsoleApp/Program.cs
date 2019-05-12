using HtmlAgilityPack;
using MyAuto.Dao;
using MyAuto.DataStructure.GraphData;
using MyAuto.DataStructure.SortAlgorithms;
using MyAuto.Entity;
using MyAuto.ICacheService;
using MyAuto.OfficeService;
using MyAuto.RabbitMQModule;
using MyAuto.WebCrawler;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START...");

            #region rabbitmq注释
            //HelloWorldRabbit rabbitMQMethod = new HelloWorldRabbit();
            ////rabbitMQMethod.SendMsg();
            //rabbitMQMethod.ReceiveMsg("defaultqueue","");
            #endregion

            #region Redis测试
            //RedisHelper redisHelper = new RedisHelper();
            //redisHelper.Insert("hello", "first Redis", 2);
            //Thread.Sleep(1 * 1000);
            //var a = redisHelper.Get("hello") ?? "空";
            //Console.WriteLine("hello的值为：{0}", a);
            //Thread.Sleep(2 * 1000);
            //var b = redisHelper.Get("hello") ?? "空";
            //Console.WriteLine("hello的值为：{0}", b);
            #endregion

            #region 并行编程
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Parallel.For(0, 50, (i) =>
            //{
            //    Console.WriteLine("num : {0},线程id : {1}", i, Thread.CurrentThread.ManagedThreadId.ToString());
            //    Thread.Sleep(2 * 1000);
            //});
            //sw.Stop();
            //TimeSpan ts = sw.Elapsed;
            //Console.WriteLine("Parallel.For总共花费{0}ms.", ts.TotalSeconds);


            //Stopwatch sw2 = new Stopwatch();
            //sw2.Start();
            //for (int i = 0; i < 50; i++)
            //{
            //    Console.WriteLine("num : {0},线程id : {1}", i, Thread.CurrentThread.ManagedThreadId.ToString());
            //    Thread.Sleep(2 * 1000);
            //}
            //sw2.Stop();
            //TimeSpan ts2 = sw2.Elapsed;
            //Console.WriteLine("for总共花费{0}ms.", ts2.TotalSeconds);

            #endregion

            #region 图数据结构
            //GraphDataHandler myGraphHandler = new GraphDataHandler();
            //myGraphHandler.InitGraph();
            #endregion

            #region 算法
            ////WordService wordService = new WordService();

            //////string a  = wordService.TiquWord("F:\\文档测试\\1.doc");
            ////wordService.Tiqu2("F:\\文档测试\\1.docx");
            //Sort a = new Sort();
            //List<int> list = new List<int>();
            //list.Add(7);
            //list.Add(3);
            //list.Add(9);
            //list.Add(6);
            //list.Add(2);
            //list.Add(22);
            //list.Add(4);
            //list.Add(8);
            ////list.Add(8);
            ////list.Add(7);
            ////list.Add(6);
            ////list.Add(5);
            ////list.Add(4);
            ////list.Add(3);
            ////list.Add(2);
            ////list.Add(1);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write(list[i] + "\t");
            //}
            //Console.WriteLine("\n");
            ////list.Sort();
            //a.BubbleSortPrint(list);
            //Console.WriteLine("Sort   Sort   Sort   Sort   Sort");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            #endregion

            #region 提取a标签中的链接
            //CrawlerMethods.CreateInstance().LinkMesgForHtmlString();
            //CrawlerMethods.CreateInstance().PicLinkForHtmlString("");

            CrawlerMain crawlerMain = new CrawlerMain();
            crawlerMain.StartWeb();

            #endregion




            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}
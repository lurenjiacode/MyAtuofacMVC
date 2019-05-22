using HtmlAgilityPack;
using MyAuto.CSharpCore;
using MyAuto.Dao;
using MyAuto.DataStructure.GraphData;
using MyAuto.DataStructure.SortAlgorithms;
using MyAuto.Elasticsearch;
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

            MyWait myWait = new MyWait();

            //var a = myWait.TaskWait();//5
            //var b = myWait.TaskWaitSecond();//3
            //var c = myWait.TaskWait(8);//8
            //a.Start();
            //b.Start();
            //c.Start();
            //Task.WaitAll(a, b, c);
            myWait.TaskWaitAsync();

            #endregion

            #region 图数据结构
            //GraphDataHandler myGraphHandler = new GraphDataHandler();
            //myGraphHandler.InitGraph();
            #endregion

            #region 提取文字注释
            ////WordService wordService = new WordService();
            //////string a  = wordService.TiquWord("F:\\文档测试\\1.doc");
            ////wordService.Tiqu2("F:\\文档测试\\1.docx");
            #endregion

            #region 排序算法
            //List<int> randomnums = new List<int>();
            //try
            //{
            //    randomnums = NumData.RandomInt(3, 50, 10);
            //    //foreach (var randomnum in randomnums)
            //    //{
            //    //    Console.WriteLine("NUM:" + randomnum);
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    string error = ex.Message;
            //}
            //finally { }
            //Sort sort = new Sort();
            //List<int> list = new List<int>();
            //list = randomnums;
            //Console.WriteLine("输入数组：");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write(list[i] + "\t");
            //}
            //Console.WriteLine("数组输入结束");
            //Console.WriteLine("开始排序：");
            ////list.Sort();
            ////sort.BubbleSortPrint(list);
            ////sort.QuickSort2(list,0, list.Count-1);
            ////sort.StraightInsertionSort(list);
            //sort.InsertionSort(list);
            //Console.WriteLine("Sort   Sort   Sort   Sort   Sort");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    //Console.WriteLine(list[i]);
            //    Console.Write(list[i] + "\t");
            //}
            #endregion

            #region 爬取网页中的链接
            //CrawlerMain crawlerMain = new CrawlerMain();
            //crawlerMain.StartWeb();

            //CrawlerMethods crawlerMethods = new CrawlerMethods();
            //crawlerMethods.GetText("");
            #endregion


            #region //ElasticSearch
            //var eshelper = ElasticSearchHelper.Intance;



            #endregion






            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}
using MyAuto.Dao;
using MyAuto.Entity;
using MyAuto.WebCrawler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START...");

            CrawlerMethods.CreateInstance().PicLinkForHtmlString();


            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}

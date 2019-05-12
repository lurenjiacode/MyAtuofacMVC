using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.WebCrawler
{
    public class CrawlerMain
    {
        //
        private readonly string MAINURL = "";
        CrawlerInfo crawlerInfo = new CrawlerInfo();
        public void StartWeb()
        {
            
            #region 生成以及url
            var urls = CreateOneLevelUrls(2,500);
            foreach (var url in urls)
            {
                string html= crawlerInfo.StartCrawler(url);
                var lists = CrawlerMethods.CreateInstance().GetPicUrlList(html);
                
                foreach (var picmod in lists)
                {
                    //count += 1;
                    if (!string.IsNullOrEmpty(picmod.Name) && picmod.Name.Length > 11)
                    {
                        Console.WriteLine("" + picmod.Name.Substring(0, 10) + "开始");
                    }
                    else if (!string.IsNullOrEmpty(picmod.Name))
                    {
                        Console.WriteLine("" + picmod.Name + "开始");
                    }
                    CrawlerMethods.CreateInstance().PicLinkForHtmlString(picmod);
                    Console.WriteLine("" + picmod.Name + "结束");
                }
                //这里不能并行处理
                //Parallel.For(0, lists.Count, (item) =>
                //{
                //    CrawlerMethods.CreateInstance().PicLinkForHtmlString(lists[lists.Count - 1]);
                //});

            }
            #endregion

        }


        public List<string> CreateOneLevelUrls(int startpage, int endpage)
        {
            List<string> onelevels = new List<string>();//一级url用于提取连接
            if (startpage == 1)
            {
                onelevels.Add(MAINURL + "/html/part/20.html");
            }
            for (int i = startpage; i < endpage; i++)
            {
                string url = MAINURL + "/html/part/20_" + i + ".html";
                onelevels.Add(url);
            }
            return onelevels;
        }
        public List<string> CreateOneLevelUrlss(int startpage, int endpage)
        {
            List<string> onelevels = new List<string>();//一级url用于提取连接
            if (startpage == 1)
            {
                onelevels.Add(MAINURL + "/html/part/19.html");
            }
            for (int i = startpage; i < endpage; i++)
            {
                string url = MAINURL + "/html/part/19_" + i + ".html";
                onelevels.Add(url);
            }
            return onelevels;
        }
        public List<string> CreateOneLevelUrlsa(int startpage, int endpage)
        {
            List<string> onelevels = new List<string>();//一级url用于提取连接
            onelevels.Add(MAINURL + "/html/part/19.html");
            for (int i = startpage; i < endpage; i++)
            {
                string url = MAINURL + "/html/part/19_" + i + ".html";
                onelevels.Add(url);
            }
            return onelevels;
        }

    }
}

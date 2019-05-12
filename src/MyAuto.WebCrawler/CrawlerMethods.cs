using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.WebCrawler
{
    public class PicMode
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }


   public class CrawlerMethods
    {
        readonly CrawlerInfo crawlerInfo = new CrawlerInfo();

        WebClient wc = new WebClient();
        private static int i = 0;
        private static CrawlerMethods _crawlerMethods = null;
        public static CrawlerMethods CreateInstance()
        {
            if (_crawlerMethods == null)
            {
                _crawlerMethods = new CrawlerMethods();
            }
            return _crawlerMethods;
        }
        
        public void LinkMesgForHtmlString()
        {
            HtmlDocument htmlDoc = new HtmlDocument();

            //string a = crawlerInfo.StartCrawler();
            //htmlDoc.LoadHtml(a);
            htmlDoc.LoadHtml(File.ReadAllText("D:\\aa.html"));
            

            //htmlDoc.Load("D:\\aa.html");
            //HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='container navigation']").SelectSingleNode("//ul[@class='pc-nav']").SelectNodes(".//a[@href]");
            HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='list']").SelectNodes(".//a[@title]");
            if (hrefList != null)
            {
                foreach (HtmlNode href in  hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    string aInterText = href.InnerText;
                    string[] namelist = aInterText.Split('[');
                    string name = namelist[0].ToString();
                    Console.WriteLine("num:" + "内容：" + name + "\n链接：" + att.Value);
                }
            }
            Console.WriteLine("END Crawler !!!!!!!!!!!!!!!!!!!!!");
        }
        public List<PicMode> GetPicUrlList(string htmlstr)
        {
            List<PicMode> urls = new List<PicMode>();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlstr);
            HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='list']").SelectNodes(".//a[@title]");
            if (hrefList != null)
            {
                foreach (HtmlNode href in hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    string aInterText = href.InnerText;
                    string[] namelist = aInterText.Split('[');
                    string name = namelist[0].ToString();
                    Console.WriteLine("num:" + "内容：" + aInterText + "\n链接：" + att.Value);
                    PicMode picMode = new PicMode();
                    picMode.Name = aInterText;
                    picMode.Url = att.Value;
                    urls.Add(picMode);
                }
            }
            return urls;
        }
        public void LinkMesgForHtmlString(string dirname,string pichtmlstr)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(pichtmlstr);
            HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='list']").SelectNodes(".//a[@title]");
            if (hrefList != null)
            {
                foreach (HtmlNode href in hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    string aInterText = href.InnerText;
                    string[] namelist = aInterText.Split('[');
                    string name = namelist[0].ToString();
                    Console.WriteLine("num:" + "内容：" + aInterText + "\n链接：" + att.Value);
                    LinkMesgForHtmlString(aInterText, "");
                }
            }
            //Console.WriteLine("END Crawler !!!!!!!!!!!!!!!!!!!!!");
        }

        public void PicLinkForHtmlString()
        {
            string htmlstr = crawlerInfo.StartCrawler();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlstr);
            HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectNodes("//img");
            if (hrefList != null)
            {
                //foreach (HtmlNode href in hrefList)
                //{
                //    if (href.Attributes["src"] == null)
                //        continue;
                //    string imgurl = href.Attributes["src"].Value.ToString();
                    
                //    if (!imgurl.Contains("runoob.com"))
                //    {
                //        imgurl = "//www.runoob.com" + imgurl;
                //    }
                //    //DownLoadImg(imgurl);
                //    bool downFlg = DownFile(imgurl, @"F:\1\", NewFileName);
                //    Console.WriteLine("图片链接:" + imgurl);
                //}
                for (int i = 0; i < hrefList.Count; i++)
                {
                    HtmlNode href = hrefList[i];
                    if (href.Attributes["src"] == null)
                        continue;
                    string imgurl = href.Attributes["src"].Value.ToString();

                    //if (!imgurl.Contains("runoob.com"))
                    //{
                    //    imgurl = @"https://www.runoob.com" + imgurl;
                    //}
                    if (!string.IsNullOrEmpty(imgurl) && imgurl.Substring(0, 2).Equals("//"))
                    {
                        imgurl = @"https:" + imgurl;
                    }
                    //DownLoadImg(imgurl);
                    string kzName = Path.GetExtension(imgurl);
                    bool downFlg = DownFile(imgurl, @"F:\1", i.ToString() + kzName);
                    Console.WriteLine("图片存储:" + downFlg + ",\t\t图片链接:" + imgurl);
                    //Console.WriteLine(",\t\t图片链接:" + imgurl);
                }
            }
            Console.WriteLine("END Crawler !!!!!!!!!!!!!!!!!!!!!");
        }
        public void PicLinkForHtmlString(PicMode picMode)
        {
            string htmlstr = crawlerInfo.StartCrawler(picMode.Url);
            HtmlDocument htmlDoc = new HtmlDocument();
            if (!string.IsNullOrEmpty(htmlstr))
            {
                htmlDoc.LoadHtml(htmlstr);
                HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='n_bd']").SelectNodes(".//img[@src]");// ".//img[@src]   // //img
                if (hrefList != null)
                {
                    #region 原for循环注释
                    //for (int i = 0; i < hrefList.Count; i++)
                    //{
                    //    HtmlNode href = hrefList[i];
                    //    if (href.Attributes["src"] == null)
                    //        continue;
                    //    string imgurl = href.Attributes["src"].Value.ToString();
                    //    string kzName = Path.GetExtension(imgurl);
                    //    bool downFlg = DownFile(imgurl, @"F:\1\" + picMode.Name, i.ToString() + kzName);
                    //    Console.WriteLine("图片存储:" + downFlg + ",\t\t图片链接:" + imgurl);
                    //}
                    #endregion
                    #region 并行处理
                    Parallel.For(0, hrefList.Count, (item) =>
                    {
                        HtmlNode href = hrefList[item];
                        if (href.Attributes["src"] == null)
                        { }
                        string imgurl = href.Attributes["src"].Value.ToString();
                        string kzName = Path.GetExtension(imgurl);
                        bool downFlg = DownFile(imgurl, @"F:\2\" + picMode.Name, item.ToString() + kzName);
                        Console.WriteLine("图片存储:" + downFlg + ",\t\t图片链接:" + imgurl);
                    });
                    #endregion

                }
                Console.WriteLine("END List Crawler !!!!!!!!!!!!!!!!!!!!!");
            }
            
        }
        public bool DownFile(string url, string LocalPath, string FileName)
        {
            try
            {
                Uri uri = new Uri(url);
                WebClient client = new WebClient();
                //HttpWebRequest request = (HttpWebRequest)client.GetWebRequest(uri);

                if (!Directory.Exists(LocalPath))
                    Directory.CreateDirectory(LocalPath);
                client.DownloadFile(uri, LocalPath + "\\" + FileName);
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }

    }

   
}

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
    public class CrawlerMethods
    {
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
        readonly CrawlerInfo crawlerInfo = new CrawlerInfo();
        public void LinkMesgForHtmlString()
        {
            string a = crawlerInfo.StartCrawler();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(a);
            HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='container navigation']").SelectSingleNode("//ul[@class='pc-nav']").SelectNodes(".//a[@href]");
            //if (hrefList != null)
            //{
            //    for (int i = 0; i < hrefList.Count; i++)
            //    {
            //        HtmlNode href = hrefList[i];
            //        HtmlAttribute att = href.Attributes["href"];
            //        string aInterText = href.InnerText;
            //        Console.WriteLine("num:" + i + "，内容：" + aInterText + ",\t链接：" + att.Value);
            //    }
            //}
            if (hrefList != null)
            {
                foreach (HtmlNode href in  hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    string aInterText = href.InnerText;
                    Console.WriteLine("num:" + href.Id + "，内容：" + aInterText + ",\t链接：" + att.Value);
                }
            }
            Console.WriteLine("END Crawler !!!!!!!!!!!!!!!!!!!!!");
        }

        public void PicLinkForHtmlString()
        {
            string htmlstr = crawlerInfo.StartCrawler();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlstr);
            HtmlNodeCollection imgList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='newslist']").SelectNodes("//img");
            //HtmlNodeCollection hrefList = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='list']").SelectSingleNode("//div[@class='info']").SelectNodes("//h4[@title]");
            if (imgList != null)
            {
                for (int i = 0; i < imgList.Count; i++)
                {
                    HtmlNode href = imgList[i];
                    HtmlNode href2 = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='list']").SelectSingleNode("//div[@class='info']").SelectSingleNode("//h4[@title]");
                    if (href.Attributes["src"] == null)
                        continue;
                    string imgurl = href.Attributes["src"].Value.ToString();

                    string aInterText = href2.InnerText;

                    //if (!imgurl.Contains("runoob.com"))
                    //{
                    //    imgurl = @"https://www.runoob.com" + imgurl;
                    //}
                    if (!string.IsNullOrEmpty(imgurl) && imgurl.Substring(0, 2).Equals("//"))
                    {
                        imgurl = @"https:" + imgurl;
                    }

                   


                    string kzName = Path.GetExtension(imgurl);
                    //bool downFlg = DownFile(imgurl, @"F:\1", i.ToString() + kzName);
                    //Console.WriteLine("图片存储:" + downFlg + ",\t\t图片链接:" + imgurl);
                    Console.WriteLine(",\t\t图片链接:" + imgurl +",名称："+ aInterText);
                }
            }
            Console.WriteLine("END Crawler !!!!!!!!!!!!!!!!!!!!!");
        }
        
        public void DownLoadImg(string url)
        {
            i++;
            string newfilename = i + ".jpg";
            string filepath = @"F:\1\" + newfilename;
            try
            {
                wc.DownloadFile(url, filepath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("错误:" + ex.Message);
            }
            finally { }

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

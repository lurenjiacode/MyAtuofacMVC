using MyAuto.Common;
using MyAuto.Entity;
using MyAuto.IService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using static System.Net.WebRequestMethods;

namespace MyAuto.WebApp.Controllers
{
    public class BlogController : Controller
    {

        private IBlogArticleService _blogArticleService;
        //构造器注入
        public BlogController(IBlogArticleService blogArticleService)
        {
            this._blogArticleService = blogArticleService;
        }


        [Route("Blog")]
        [Route("Blog/page{pageindexa}")]
        public ActionResult Index(int pageindexa = 1)
        {
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ViewBag.Message = "Your application description page.";
            ViewBag.Hellotime = datatime;
            var bloglist = _blogArticleService.GetList();
            //第几页  
            int pageNumber = pageindexa;
            //每页显示多少条
            int pageSize = 10;
            IPagedList<BlogArticle> blogPagedList = bloglist.ToPagedList(pageNumber, pageSize);
            return View(blogPagedList);
        }



        //[Authorize]
        [AllowAnonymous]
        public ActionResult Add()
        {
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ViewBag.Message = "Your application description page.";
            ViewBag.Hellotime = datatime;
            return View();
        }

       
        public int AddBlog()
        {
            var sr = new StreamReader(Request.InputStream);
            var json = sr.ReadToEnd();
            BlogArticle blogArticle = new BlogArticle();
            int i = 0;
            try
            {
                blogArticle = JsonConvert.DeserializeObject<BlogArticle>(json);
                blogArticle.BlogCreateTime = DateTime.Now;
                i = _blogArticleService.Add(blogArticle);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally
            { }

            return i > 0 ? 999 : 0;
        }


        [Route("Blog/title_{pageindexa}")]
        public ActionResult Show(int pageindexa = 1)
        {
            var a = pageindexa;
            //BlogArticle blogArticle = new BlogArticle();
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ViewBag.Message = "Your application description page.";
            ViewBag.Hellotime = datatime;
            BlogArticle blogArticle = _blogArticleService.Get(pageindexa);
            ViewBag.BlogID = blogArticle.BlogID;
            ViewBag.BlogTitle = blogArticle.Title;
            ViewBag.BlogKeywords = blogArticle.Keywords;
            ViewBag.BlogCreator = blogArticle.Creator;
            ViewBag.BlogContent = DESEncrypt.Base64Decrypt(blogArticle.BlogContent);
            ViewBag.BlogCreateTime = blogArticle.BlogCreateTime.ToString("yyyy-MM-dd HH:mm");

            return View();
        }


        public string GetBlog()
        {
            var sr = new StreamReader(Request.InputStream);
            var json = sr.ReadToEnd();
            var a = json;
            JObject json1 = (JObject)JsonConvert.DeserializeObject(json);
            var aa = json1["BlogID"].ToString();
            var blog = _blogArticleService.Get(int.Parse(aa));

            return DESEncrypt.Base64Decrypt(blog.BlogContent);
        }


        private void Source()
        {
            Hashtable hashtable = new Hashtable();
            Dictionary<int,string> a = new Dictionary<int, string>();
        }
    }
}
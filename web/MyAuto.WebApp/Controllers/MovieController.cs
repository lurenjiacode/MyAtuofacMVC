using MyAuto.Entity;
using MyAuto.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace MyAuto.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        //构造器注入
        public MovieController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        // GET: Mov
        [Route("Movie")]
        [Route("Movie/page{pageindexa}")]
        public ActionResult Index(int pageindexa = 1)
        {
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ViewBag.Message = "Movies application show page";
            ViewBag.Hellotime = datatime;
            var movies = _movieService.GetList();
            //第几页  
            int pageNumber = pageindexa;
            //每页显示多少条
            int pageSize = 10;
            IPagedList<Movie> moviePagedList = movies.ToPagedList(pageNumber, pageSize);
            return View(moviePagedList);
        }


        [Route("Movie/play_{pageindexa}")]
        public ActionResult Play(int pageindexa = 1)
        {
            var a = pageindexa;
            //BlogArticle blogArticle = new BlogArticle();
            string datatime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ViewBag.Message = "Your application description page.";
            ViewBag.Hellotime = datatime;
            Movie movie = _movieService.Get(pageindexa);
            ViewBag.MovID = movie.MovID;
            ViewBag.MovName = movie.MovName;
            ViewBag.Classify = movie.Classify;
            ViewBag.Performer = movie.Performer;
            ViewBag.FileName = movie.FileName;
            ViewBag.MovieCreateTime = movie.MovieCreateTime;
            return View();
        }
    }
}
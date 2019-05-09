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
        //[Route("Movie")]
        //[Route("Movie/page{pageindexa}")]
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

        public ActionResult Play()
        {
            return View();
        }
    }
}
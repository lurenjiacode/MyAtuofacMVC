using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAuto.WebApp.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat

        [Route("Chat")]
        [Route("Chat/Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
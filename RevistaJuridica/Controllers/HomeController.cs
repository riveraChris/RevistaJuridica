using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RevistaJuridica.EventRepositories;
using RevistaJuridica.ArticleRepositories;

namespace RevistaJuridica.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly EventRepository eventRepo = new EventRepository();
        private readonly ArticleRepository articleRepo = new ArticleRepository();

        public ActionResult Index()
        {
            return View ();
        }

        [ChildActionOnly]
        public ActionResult Events()
        {
            return PartialView("~/Views/Event/_Events.cshtml", eventRepo.GetTopEvents(3));
        }

        [ChildActionOnly]
        public ActionResult Articles()
        {
            return PartialView("~/Views/Article/_Articles.cshtml", articleRepo.GetDefaultArticles()) ;
        }
    }
}
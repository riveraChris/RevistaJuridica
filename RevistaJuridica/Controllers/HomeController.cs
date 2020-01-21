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
        private readonly ArticleRepository articRepo = new ArticleRepository();

        public ActionResult Index()
        {
            return View ();
        }

        [ChildActionOnly]
        public ActionResult Events()
        {
            return PartialView("~/Views/Event/Index.cshtml", eventRepo.GetTopEvents(2));
        }

        [ChildActionOnly]
        public ActionResult Articles()
        {
            return PartialView("~/Views/Article/Index.cshtml", articRepo.GetTopArticles(2));
        }
    }
}
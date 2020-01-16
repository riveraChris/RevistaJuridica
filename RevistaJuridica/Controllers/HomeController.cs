using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using RevistaJuridica.Models;
using RevistaJuridica.EventRepositories;

namespace RevistaJuridica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EventRepository e = new EventRepository();

            return View(e.GetEvent(1));
        }
    }
}

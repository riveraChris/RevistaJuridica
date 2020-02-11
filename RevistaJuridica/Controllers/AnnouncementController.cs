using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RevistaJuridica.Repositories;

namespace RevistaJuridica.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly AnnouncementRepository repo = new AnnouncementRepository();

        public ActionResult Index()
        {
            return View (repo.GetAllAnnouncement());
        }
    }
}

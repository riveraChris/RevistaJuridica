using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RevistaJuridica.Repositories;

namespace RevistaJuridica.Controllers
{
    public class EditionController : Controller
    {
        private readonly EditionRepository repo = new EditionRepository();

        public ActionResult Index()
        {
            return View(repo.GetAllEditionsWithNumbersAndArticles());
        }
    }
}

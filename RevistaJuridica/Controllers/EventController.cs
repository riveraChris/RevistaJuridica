using System;
using System.Web.Mvc;
using RevistaJuridica.Models;
using RevistaJuridica.EventRepositories;

namespace RevistaJuridica.Controllers
{
    public class Event : Controller
    {
        private readonly EventRepository repo = new EventRepository();

        public ActionResult Index()
        {
           
            return View(repo.GetAllEvents());
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Models.Event e)
        {
            e.EventDate = DateTime.Now;

            repo.InsertEvent(e);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var e = repo.GetEvent(id);

            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Models.Event e)
        {
            repo.UpdateEvent(e);
     
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Models.Event e)
        {
            repo.DeleteEvent(e);

            return RedirectToAction("Index");
        }
    }
}

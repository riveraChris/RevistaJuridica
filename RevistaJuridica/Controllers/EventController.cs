using System;
using System.Web.Mvc;
using RevistaJuridica.Models;
using RevistaJuridica.EventRepositories;

namespace RevistaJuridica.Controllers
{
    public class EventController : Controller
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
        public ActionResult New(Event e)
        {
            e.EventDate = DateTime.Now;

            _ = repo.InsertEvent(e);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var e = repo.GetEvent(id);

            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Event e)
        {
            repo.UpdateEvent(e);
     
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Event e)
        {
            repo.DeleteEvent(e);

            return RedirectToAction("Index");
        }
    }
}

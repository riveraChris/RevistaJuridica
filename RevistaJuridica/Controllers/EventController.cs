using System;
using System.Web.Mvc;
using RevistaJuridica.Models;
using RevistaJuridica.EventRepositories;
using System.Web;
using System.IO;
using RevistaJuridica.Repositories;

namespace RevistaJuridica.Controllers
{
    public class EventController : Controller
    {
        private readonly EventRepository repo = new EventRepository();

        public ActionResult Index()
        {
           
            return View(repo.GetAllEvents());
        }

        public ActionResult Details(long id)
        {
            var e = repo.GetEventWithImage(id);

            return View("Details", e);
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
        public ActionResult Edit(Event e, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Documents/Events"), Path.GetFileName(file.FileName));

                    //Document Validation
                    DocumentRepository docRepo = new DocumentRepository();

                    Document eventImage = repo.GetEventImage(e.Id);

                    if(eventImage != null)
                    {
                        // Remove Old Image
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Documents/Events"), eventImage.Name));

                        Document newEventImage = new Document();
                        eventImage.Name = file.FileName;
                        eventImage.Type = file.ContentType;
                        eventImage.Size = file.ContentLength;
                        eventImage.Path = path;
                  
                        //Update Event Image information
                        docRepo.UpdateDocument(eventImage);
                    }
                    else
                    {
                        Document newEventImage = new Document();

                        newEventImage.Name = file.FileName;
                        newEventImage.Type = file.ContentType;
                        newEventImage.Size = file.ContentLength;
                        newEventImage.Path = path;
                        newEventImage.SourceTypeId = docRepo.GetDocumentSourceTypeId("DocumentSource", "EventImage");

                        //Save new Image information
                        docRepo.InsertDocument(newEventImage);
                    }
                    // Save Image on Server
                    file.SaveAs(path);

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            repo.UpdateEvent(e);

            return RedirectToAction("Edit");
        }

        public ActionResult Delete(Event e)
        {
            repo.DeleteEvent(e);

            return RedirectToAction("Index");
        }
    }
}

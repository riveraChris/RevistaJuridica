using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using RevistaJuridica.ArticleRepositories;
using RevistaJuridica.Models;

namespace RevistaJuridica.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleRepository repo = new ArticleRepository();

        public ActionResult Index()
        {

            return View(repo.GetAllArticles());
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Article e)
        {
            e.ArticleDate = DateTime.Now;

            repo.InsertArticle(e);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var e = repo.GetArticle(id);

            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Article e, HttpPostedFileBase file)
        {
            
            string theFileName = Path.GetFileName(file.FileName);
            byte[] thePictureAsBytes = new byte[file.ContentLength];
            using (BinaryReader theReader = new BinaryReader(file.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
            }
            string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
            

            //Update fields
            e.ArticleImage = thePictureAsBytes;

            //file.InputStream.Read(e.ArticleImage, 0, file.ContentLength);

            repo.UpdateArticle(e);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Models.Article e)
        {
            repo.DeleteArticle(e);

            return RedirectToAction("Index");
        }
    }
}

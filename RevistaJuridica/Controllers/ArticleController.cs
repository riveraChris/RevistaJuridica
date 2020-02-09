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
            repo.InsertArticle(e);

            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            var e = repo.GetArticle(id);

            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Article e)
        {
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

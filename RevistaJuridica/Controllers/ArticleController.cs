using System;
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
        public ActionResult Edit(Article e)
        {
            repo.UpdateArticle(e);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            repo.DeleteArticle(id);

            return RedirectToAction("Index");
        }
    }
}

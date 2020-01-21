using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RevistaJuridica.Models;
using System.Collections.Generic;
using System.Linq;

namespace RevistaJuridica.ArticleRepositories
{
    public class ArticleRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public IEnumerable<Article> GetAllArticles()
        {
            return _db.GetAll<Article>();
        }

        public IEnumerable<Article> GetTopArticles(int top)
        {
            return _db.Query<Article>("select top " + top + " * from dbo.Article order by ArticleDate DESC").ToList();
        }

        public Article GetArticle(long id)
        {
            return _db.Get<Article>(id);
        }

        public long InsertArticle(Article e)
        {
           return _db.Insert<Article>(e);
        }

        public void UpdateArticle(Article e)
        {
            e.ArticleDate = DateTime.Now.Date;
            
            _db.Update<Article>(e);

        }

        public void DeleteArticle(Article e)
        {
            _db.Delete<Article>(e);
        }
    }
}

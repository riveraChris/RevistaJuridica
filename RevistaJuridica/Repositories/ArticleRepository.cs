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

        public List<Article> GetAllArticles()
        {

            List<Article> e = _db.Query<Article>("select * from dbo.Article").ToList();

            return e;
        }

        public Article GetArticle(long id)
        {

            Article e = _db.Query<Article>("select * from dbo.Article where ArticleId=" + id).FirstOrDefault();

            return e;
        }

        public void InsertArticle(Article e)
        {
            string query = "insert into dbo.Article Values('" + e.Name + "','" + e.Description + "',cast('" + e.ArticleDate + "' as datetime))";

            _db.Query(query);
        }

        public void UpdateArticle(Article e)
        {
            string query = "update dbo.Article set Name='" + e.Name + "',Description='" + e.Description + "',ArticleDate=getdate() where ArticleId=" + e.ArticleId;

            _db.Query(query);
        }

        public void DeleteArticle(long id)
        {
            string query = "Delete from dbo.Article where ArticleId=" + id;

            _db.Query(query);
        }
    }
}

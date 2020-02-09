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

        public IEnumerable<Article> GetDefaultArticles()
        {
            return _db.Query<Article>("sp_GetDefaultArticles").ToList();
        }

        public Article GetArticle(long id)
        {
            return _db.Get<Article>(id);
        }

        public long InsertArticle(Article e)
        {
           return _db.Insert(e);
        }

        public void UpdateArticle(Article e)
        {   
            _db.Update(e);
        }

        public void DeleteArticle(Article e)
        {
            _db.Delete(e);
        }
    }
}

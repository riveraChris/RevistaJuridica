using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using RevistaJuridica.Models;

namespace RevistaJuridica.Repositories
{
    public class EditionRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public IEnumerable<Edition> GetAllEditions()
        {
            return _db.GetAll<Edition>();
        }

        public IEnumerable<Edition> GetAllEditionsWithNumbers()
        {
            var Editions = _db.GetAll<Edition>();

            foreach (var edition in Editions)
            {
                var selectNumbers = _db.Query<Number>("select * from dbo.Number where EditionId=" + edition.Id).ToList();
                edition.setAllEditionNumbers(selectNumbers);
            }

            return Editions;
        }

        public IEnumerable<Edition> GetAllEditionsWithNumbersAndArticles()
        {
            var Editions = _db.GetAll<Edition>();

            foreach (var edition in Editions)
            {
                var selectNumbers = _db.Query<Number>("select * from dbo.Number where EditionId=" + edition.Id).ToList();
                edition.setAllEditionNumbers(selectNumbers);

                foreach(var number in edition.Numbers)
                {
                    var selectArticle = _db.Query<Article>("select * from dbo.Article where NumberId=" + number.Id).ToList();
                    number.SetAllNumberArticles(selectArticle);
                }
            }

            return Editions;
        }

        public Edition GetEdition(long id)
        {
            return _db.Get<Edition>(id);
        }

        public long InsertEdition(Edition e)
        {
            return _db.Insert(e);
        }

        public void UpdateEdition(Edition e)
        { 
            _db.Update(e);
        }

        public void DeleteEdition(Edition e)
        {
            _db.Delete(e);
        }
    }
}

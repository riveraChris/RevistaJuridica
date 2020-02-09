using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using RevistaJuridica.Models;

namespace RevistaJuridica.Repositories
{
    public class NumberRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public IEnumerable<Number> GetAllNumber()
        {
            return _db.GetAll<Number>();
        }

        public Number GetNumber(long id)
        {
            return _db.Get<Number>(id);
        }

        public long InsertNumber(Number e)
        {
            return _db.Insert<Number>(e);
        }

        public void UpdateNumber(Number e)
        {
            _db.Update<Number>(e);
        }

        public void DeleteNumber(Number e)
        {
            _db.Delete<Number>(e);
        }
    }
}

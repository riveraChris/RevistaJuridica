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

namespace RevistaJuridica.EventRepositories
{
    public class EventRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<Event> GetAllEvents()
        { 

            List<Event> e = _db.Query<Event>("select * from dbo.Event").ToList();

            return e;
        }

        public Event GetEvent(long id)
        {
      
            Event e = _db.Query<Event>("select * from dbo.Event where EventId=" + id).FirstOrDefault();

            return e;
        }

        public void InsertEvent(Event e)
        {
            string query = "insert into dbo.Event Values('" + e.Name + "','" + e.Description + "',cast('" + e.EventDate + "' as datetime))";

            _db.Query(query);
        }

        public void UpdateEvent(Event e)
        {
            string query = "update dbo.Event set Name='" + e.Name + "',Description='" + e.Description + "',EventDate=getdate() where EventId=" + e.EventId;

            _db.Query(query);
        }

        public void DeleteEvent(long id)
        {
            string query = "Delete from dbo.Event where EventId=" + id;

            _db.Query(query);
        }
    }
}

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

        public IEnumerable<Event> GetAllEvents()
        {
            return _db.GetAll<Event>();
        }

        public IEnumerable<Event> GetTopEvents(int top)
        {
            return _db.Query<Event>("sp_GetLastestEvents @Num=" + top).ToList();
        }

        public Event GetEvent(long id)
        {
            return _db.Get<Event>(id);
        }

        public Document GetEventImage(long id)
        {
            return _db.Query<Document>("sp_GetEventDocument @EventId=" + id).FirstOrDefault();
        }

        public Event GetEventWithImage(long id)
        {
            var e = _db.Get<Event>(id);
            e.setEventImage(GetEventImage(e.Id));

            return e;
        }

        public long InsertEvent(Event e)
        {
            return _db.Insert<Event>(e);
        }

        public void UpdateEvent(Event e)
        {
            _db.Update<Event>(e);
        }

        public void DeleteEvent(Event e)
        {
            _db.Delete<Event>(e);
        }
    }
}

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
    public class AnnouncementRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public IEnumerable<Announcement> GetAllAnnouncement()
        {
            return _db.GetAll<Announcement>();
        }

        public Announcement GetAnnouncement(long id)
        {
            return _db.Get<Announcement>(id);
        }

        public Document GetAnnouncementImage(long id)
        {
            return _db.Query<Document>("sp_GetAnnouncementDocument @EventId=" + id).FirstOrDefault();
        }

        public Announcement GetAnnouncementWithImage(long id)
        {
            var e = _db.Get<Announcement>(id);
            e.setAnnouncementImage(GetAnnouncementImage(e.Id));

            return e;
        }

        public long InsertAnnouncement(Announcement e)
        {
            return _db.Insert(e);
        }

        public void UpdateAnnouncement(Announcement e)
        {
            _db.Update(e);
        }

        public void DeleteAnnouncement(Announcement e)
        {
            _db.Delete(e);
        }
    }
}

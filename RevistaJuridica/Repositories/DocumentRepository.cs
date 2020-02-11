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

namespace RevistaJuridica.Repositories
{
    public class DocumentRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public IEnumerable<Document> GetAllDocuments()
        {
            return _db.GetAll<Document>();
        }

        public Document GetDocument(long id)
        {
            return _db.Get<Document>(id);
        }

        public long GetDocumentSourceTypeId(string type, string description)
        {
            //var parameters = new DynamicParameters();
            //parameters.Add("@Type", dbType: DbType.String, value: type, direction: ParameterDirection.Input);
            //parameters.Add("@Description", dbType: DbType.String, value: description, direction: ParameterDirection.Input);

            //return _db.Query<long>("sp_GetCatalogId @Type='" + type + "' , @Description='" + description + "'").FirstOrDefault();

            return _db.Query<long>("Select Catalog.Id from dbo.Catalog where Type='DocumentSource' and Description='EventImage'").FirstOrDefault();
        }

        public long InsertDocument(Document e)
        {
            return _db.Insert(e);
        }

        public void UpdateDocument(Document e)
        {
            _db.Update(e);
        }

        public void DeleteDocument(Document e)
        {
            _db.Delete(e);
        }
    }
}

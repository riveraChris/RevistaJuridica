using System;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    [Table("Article")]
    public class Article
    {
        [ExplicitKey]
        public long ArticleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ArticleDate { get; set; }
        public Byte[] ArticleImage { get; set; }
    }
}

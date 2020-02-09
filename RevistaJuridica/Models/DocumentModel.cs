using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    [Table("Document")]
    public class Document
    {
        [ExplicitKey]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Size { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public long SourceTypeId { get; set; }
    }
}

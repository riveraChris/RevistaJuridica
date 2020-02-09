using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    [Table("Article")]
    public class Article
    {
        [ExplicitKey]
        public long Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public string Author { get; set; }
        public bool IsDefault { get; set; }

        [Required]
        public int NumberId { get; set; }

    }
}

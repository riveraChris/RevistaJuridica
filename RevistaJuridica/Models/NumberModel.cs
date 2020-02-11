using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;


namespace RevistaJuridica.Models
{
    
    [Table("Number")]
    public class Number
    {
        [ExplicitKey]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }
        public string SubTitle { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Write(false)]
        public ICollection<Article> Articles { get; set; }

        public void SetAllNumberArticles(List<Article> a)
        {
            Articles = a;
        }
    }   
}

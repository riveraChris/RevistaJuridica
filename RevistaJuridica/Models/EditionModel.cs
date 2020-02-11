using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    [Table("Edition")]
    public class Edition
    {
        [ExplicitKey]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }

        [Write(false)]
        public ICollection<Number> Numbers { get; set; }

        public void setAllEditionNumbers(List<Number> n)
        {
            Numbers = n;
        }
    }
}

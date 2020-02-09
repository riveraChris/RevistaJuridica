using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    public class PersonModel
    {
        [Table("Person")]
        public class Person
        {
            [ExplicitKey]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Lastname { get; set; }
            [Required]
            public string Charge { get; set; }

            [Required]
            public long EditionId { get; set; }

            [Display(Name = "Full Name")]
            public string FullName
            {
                get
                {
                    return Name + " " + Lastname;
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    [Table("Event")]
    public class Event
    {
        [ExplicitKey]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public bool IsDefault { get; set; }
        public string EventLink { get; set; }

        [Write(false)]
        public Document EventImage { get; set; }

        public void setEventImage(Document d)
        {
            EventImage = d;
        }
    }
}

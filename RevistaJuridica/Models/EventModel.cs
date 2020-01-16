using System;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    public class Event
    {
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
    }
}

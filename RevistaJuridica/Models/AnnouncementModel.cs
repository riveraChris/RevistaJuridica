using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace RevistaJuridica.Models
{
    [Table("Announcement")]
    public class Announcement
    {
        [ExplicitKey]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public long AnnouncementImageId { get; set; }

        [Write(false)]
        public Document AnnouncementImage { get; set; }

        public void setAnnouncementImage(Document image)
        {
            AnnouncementImage = image;
        }
    }
}

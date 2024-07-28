using Halan.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Halan.Domain.Entities
{
    [Table("tickets")]
    public class Ticket : EntityTrackerBase
    {
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("is_handled")]
        public bool IsHandled { get; set; }

        [Column("governorate")]
        public string Governorate { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("district")]
        public string District { get; set; }
    }
}

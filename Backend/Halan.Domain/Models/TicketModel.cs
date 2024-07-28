namespace Halan.Domain.Models
{
    public class TicketModel
    {
        public class Result
        {
            public Guid Id { get; set; }
            public string PhoneNumber { get; set; }
            public bool IsHandled { get; set; }
            public string Governorate { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public DateTime CreatedDate { get; set; }
        }

        public class Query
        {
            public Guid Id { get; set; }
            public bool IsHandled { get; set; }
        }
    }
}

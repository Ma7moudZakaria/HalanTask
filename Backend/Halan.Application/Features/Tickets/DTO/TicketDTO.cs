using Halan.Common;
using static Halan.Application.Features.Tickets.Queries.GetAllTicketsQueryHandler;

namespace Halan.Application.Features.Tickets.DTO
{
    public static class TicketDTO
    {
        public class Request
        {
            public string PhoneNumber { get; set; }
            public bool IsHandled { get; set; }
            public string Governorate { get; set; }
            public string City { get; set; }
            public string District { get; set; }
        }

        public class Response
        {
            public Guid Id { get; set; }
            public string PhoneNumber { get; set; }
            public bool IsHandled { get; set; }
            public string Governorate { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public DateTime CreatedDate { get; set; }
            public TicketColor TicketColor { get; set; }
        }

        public class GetExecutionResult
        {
            public Guid Id { get; set; }
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public bool IsSuccess
            {
                get
                {
                    return string.IsNullOrEmpty(this.ErrorCode);
                }
            }
        }
    }
}

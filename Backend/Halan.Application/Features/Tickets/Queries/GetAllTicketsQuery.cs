using Halan.Application.Features.Tickets.DTO;
using Halan.Application.Repositories;
using Halan.Common;
using Halan.Domain.Entities;
using Halan.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Net.Sockets;

namespace Halan.Application.Features.Tickets.Queries
{
    public class GetAllTicketsQuery : QueryBase, IRequest<PagedList<TicketDTO.Response>>
    {
    }

    public sealed class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, PagedList<TicketDTO.Response>>
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly ILogger<GetAllTicketsQueryHandler> _logger;

        public GetAllTicketsQueryHandler(ILogger<GetAllTicketsQueryHandler> logger,
                                         ITicketRepository ticketRepo)
        {
            _logger = logger;
            _ticketRepo = ticketRepo;
        }

        public async Task<PagedList<TicketDTO.Response>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started getting list of Ticket");

            PagedList<TicketModel.Result> ticketResult = await _ticketRepo.GetAllAsync(new QueryBase
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            }, cancellationToken);

            _logger.LogInformation("Finished getting status of Internationalization");

            return new PagedList<TicketDTO.Response>
            {
                Result = ticketResult.Result.Select(item => ItemMapper(item)),
                TotalCount = ticketResult.TotalCount
            };
        }

        private static TicketDTO.Response ItemMapper(TicketModel.Result item) 
        {
            var timeElapsed = (DateTime.UtcNow - item.CreatedDate).Minutes;

            return new TicketDTO.Response
            {
                Id = item.Id,
                PhoneNumber = item.PhoneNumber,
                IsHandled = timeElapsed >= 60,
                City = item.City,
                District = item.District,
                Governorate = item.Governorate,
                CreatedDate = item.CreatedDate,
                TicketColor = GetTicketColor(item.CreatedDate)
            };            
        }

        private static TicketColor GetTicketColor(DateTime createdDate)
        {
            double diffMinutes = (DateTime.Now - createdDate).Minutes;

            if (diffMinutes < 15) return TicketColor.Yellow;
            if (diffMinutes < 30) return TicketColor.Green;
            if (diffMinutes < 60) return TicketColor.Blue;
            return TicketColor.Red;
        }
    }
}

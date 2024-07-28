using Halan.Application.Repositories;
using Halan.Common;
using Halan.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using static Halan.Application.Features.Tickets.DTO.TicketDTO;

namespace Halan.Application.Features.Tickets.Commands
{
    public class CreateTicketCommand : IRequest<GetExecutionResult>
    {
        public Request TicketRequest { get; set; }
    }

    public sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, GetExecutionResult>
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly ILogger<CreateTicketCommandHandler> _logger;

        public CreateTicketCommandHandler(ITicketRepository ticketRepo,
                                          ILogger<CreateTicketCommandHandler> logger)
        {
            _ticketRepo = ticketRepo;
            _logger = logger;
        }

        public async Task<GetExecutionResult> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // ToDo Add Validation (Fluent Validation)

            _logger.LogInformation("Started mapping ticket request to ticket");

            Ticket ticketItem = ReminderItemMapper(request.TicketRequest);

            _logger.LogInformation("Finished mapping ticket request to ticket");

            _logger.LogInformation("Started create ticket");

            if (await _ticketRepo.CreateAsync(ticketItem, cancellationToken) > 0)
            {
                _logger.LogInformation("Finished create ticket");

                return new GetExecutionResult
                {
                    Id = ticketItem.Id
                };
            }

            throw new CustomException(Constants.HttpCustomErrorCode.CustomError, "No Items have been effected", Constants.ErrorCode.NoItemEffected);
        }

        private Ticket ReminderItemMapper(Request item)
        {
            return new Ticket
            {
                Id = Guid.NewGuid(),
                Governorate = item.Governorate,
                City = item.City,
                District = item.District,
                PhoneNumber = item.PhoneNumber,
                IsHandled = item.IsHandled,
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}

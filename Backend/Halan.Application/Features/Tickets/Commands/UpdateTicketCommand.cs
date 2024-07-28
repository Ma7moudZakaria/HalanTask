using Halan.Application.Repositories;
using Halan.Common;
using Halan.Domain.Entities;
using Halan.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using static Halan.Application.Features.Tickets.DTO.TicketDTO;

namespace Halan.Application.Features.Tickets.Commands
{
    public class UpdateTicketCommand : IRequest<GetExecutionResult>
    {
        public Guid Id { get; set; }
        public bool IsHandled { get; set; }
    }

    public sealed class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, GetExecutionResult>
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly ILogger<UpdateTicketCommandHandler> _logger;

        public UpdateTicketCommandHandler(ITicketRepository ticketRepo,
                                          ILogger<UpdateTicketCommandHandler> logger)
        {
            _ticketRepo = ticketRepo;
            _logger = logger;
        }

        public async Task<GetExecutionResult> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started getting ticket from database {id}", request.Id);

            TicketModel.Result? ticket = await _ticketRepo.GetByIdAsync(request.Id, cancellationToken);

            _logger.LogInformation("Finished getting ticket from database {id}", request.Id);

            _logger.LogInformation("Started mapping ticket request to ticket");

            TicketModel.Query ticketItem = TicketItemMapperAsync(ticket.Id, request.IsHandled);

            _logger.LogInformation("Finished mapping ticket request to ticket");

            _logger.LogInformation("Started update ticket");

            if (await _ticketRepo.UpdateAsync(ticketItem, cancellationToken) > 0)
            {
                _logger.LogInformation("Finished update ticket");

                return new GetExecutionResult
                {
                    Id = ticketItem.Id
                };
            }

            throw new CustomException(Constants.HttpCustomErrorCode.CustomError, "No Items have been effected", Constants.ErrorCode.NoItemEffected);
        }

        private static TicketModel.Query TicketItemMapperAsync(Guid id, bool isHandled)
        {
            return new TicketModel.Query
            {
                Id = id,
                IsHandled = isHandled
            };
        }
    }
}

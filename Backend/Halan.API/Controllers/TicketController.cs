using Halan.Application.Features.Tickets.Commands;
using Halan.Application.Features.Tickets.DTO;
using Halan.Application.Features.Tickets.Queries;
using Halan.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Halan.Application.Features.Tickets.DTO.TicketDTO;

namespace Halan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ISender _sender;

        public TicketController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("getAll/{pageNumber}/{pageSize}")]
        [AllowAnonymous]
        public async Task<PagedList<TicketDTO.Response>> GetAll([FromRoute] int pageNumber, [FromRoute] int pageSize, CancellationToken cancellationToken)
        {
            return await _sender.Send(new GetAllTicketsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            }, cancellationToken);
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<GetExecutionResult> CreateReminder([FromBody] TicketDTO.Request ticketRequest, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new CreateTicketCommand
            {
                TicketRequest = ticketRequest
            });

            return result;
        }

        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<GetExecutionResult> UpdateReminder([FromBody] UpdateTicketCommand query, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new UpdateTicketCommand
            {
                Id = query.Id,
                IsHandled = query.IsHandled
            });

            return result;
        }
    }
}

using Halan.Common;
using Halan.Domain.Entities;
using Halan.Domain.Models;

namespace Halan.Application.Repositories
{
    public interface ITicketRepository
    {
        Task<PagedList<TicketModel.Result>> GetAllAsync(QueryBase request, CancellationToken cancellationToken);
        Task<TicketModel.Result?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<int> CreateAsync(Ticket ticket, CancellationToken cancellationToken);
        Task<int> UpdateAsync(TicketModel.Query ticket, CancellationToken cancellationToken);
    }
}

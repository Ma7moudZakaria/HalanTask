using Halan.Application.Repositories;
using Halan.Common;
using Halan.Domain.Entities;
using Halan.Domain.Models;
using Halan.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Halan.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly HalanDbContext _dbContext;
        public TicketRepository(HalanDbContext dbContext) => _dbContext = dbContext;

        public Task<int> CreateAsync(Ticket ticket, CancellationToken cancellationToken)
        {
            _dbContext.Set<Ticket>().Add(ticket);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedList<TicketModel.Result>> GetAllAsync(QueryBase request, CancellationToken cancellationToken)
        {
            return new PagedList<TicketModel.Result>
            {
                Result = await _dbContext.Set<Ticket>().Skip((request.PageNumber - 1) * request.PageSize)
                                                       .Take(request.PageSize)
                                                       .Select(a => new TicketModel.Result
                                                       {
                                                           Id = a.Id,
                                                           City = a.City,
                                                           District = a.District,
                                                           Governorate = a.Governorate,
                                                           IsHandled = a.IsHandled,
                                                           PhoneNumber = a.PhoneNumber,
                                                           CreatedDate = a.CreatedDate,
                                                       })
                                                       .ToListAsync(cancellationToken),
                TotalCount = await _dbContext.Set<Ticket>().CountAsync(cancellationToken)
            };
        }

        // We don't expose Domain Entities outsiude the domain.
        public Task<TicketModel.Result?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Set<Ticket>()
                             .Where(a => a.Id == id)
                             .Select(a => new TicketModel.Result
                             {
                                 Id = a.Id,
                                 City = a.City,
                                 District = a.District,
                                 Governorate = a.Governorate,
                                 IsHandled = a.IsHandled,
                                 PhoneNumber = a.PhoneNumber,
                             })
                             .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<int> UpdateAsync(TicketModel.Query ticket, CancellationToken cancellationToken)
        {
            return _dbContext.Set<Ticket>()
                             .Where(a => a.Id == ticket.Id)
                             .ExecuteUpdateAsync(a => a
                             .SetProperty(a => a.IsHandled, b => ticket.IsHandled)
                             .SetProperty(a => a.UpdatedDate, b => DateTime.UtcNow), cancellationToken);
        }
    }
}

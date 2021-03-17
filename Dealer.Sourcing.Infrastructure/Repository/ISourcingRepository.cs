using Dealer.Sourcing.Infrastructure.Repository.Tech;
using System;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Infrastructure.Repository
{
    public interface ISourcingRepository : IRepository<Domain.Core.Sourcing>
    {
        Task<Domain.Core.Sourcing> FindById(Guid sourcingId);
        Task<Domain.Core.Sourcing> GetAggregate(Guid sourcingId);
        Task CreateSourcing(Domain.Core.Sourcing sourcing);
    }
}

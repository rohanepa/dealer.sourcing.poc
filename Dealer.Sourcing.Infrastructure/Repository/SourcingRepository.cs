using Dealer.Sourcing.Infrastructure.Repository.Tech;
using System;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Infrastructure.Repository
{
    public class SourcingRepository : Repository<Domain.Core.Sourcing>, ISourcingRepository
    {
        public async Task<Domain.Core.Sourcing> FindById(Guid sourcingId)
        {
            return null;
        }
    }
}

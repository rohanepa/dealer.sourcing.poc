using Dealer.Sourcing.Infrastructure.Repository.Tech;
using System;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Infrastructure.Repository
{
    public class SourcingRepository : Repository<Domain.Core.Sourcing>, ISourcingRepository
    {
        public SourcingRepository(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<Domain.Core.Sourcing> FindById(Guid sourcingId)
        {
            var sourcingEntity = await Get<Models.Sourcing>(sourcingId);
            return null;
        }
    }
}

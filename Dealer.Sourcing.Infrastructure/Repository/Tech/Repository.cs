using Dealer.Sourcing.Domain.Tech;

namespace Dealer.Sourcing.Infrastructure.Repository.Tech
{
    public class Repository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregateRoot
    {
    }
}

using Dealer.Sourcing.Domain.Tech;

namespace Dealer.Sourcing.Infrastructure.Repository.Tech
{
    public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
    {
    }
}

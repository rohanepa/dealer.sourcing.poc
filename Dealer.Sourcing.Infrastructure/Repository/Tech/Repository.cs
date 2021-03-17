using Dapper.Contrib.Extensions;
using Dealer.Sourcing.Domain.Tech;
using System;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Infrastructure.Repository.Tech
{
    public abstract class Repository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregateRoot
    {
        protected readonly ConnectionFactory ConnectionFactory;

        protected Repository(ConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public async Task<T> Get<T>(Guid id) where T : class
        {
            using var connection = ConnectionFactory.GetConnection();
            return await connection.GetAsync<T>(id);
        }

        public async Task Upsert<T>(Guid id, T entity) where T : class
        {
            using var connection = ConnectionFactory.GetConnection();
            if (await Get<T>(id) != null)
                await Update(entity);
            else
            {
                await Insert(entity);
            }
        }

        public async Task<int> Insert<T>(T entity) where T : class
        {
            using var connection = ConnectionFactory.GetConnection();
            return await connection.InsertAsync(entity);
        }

        public async Task<bool> Update<T>(T entity) where T : class
        {
            using var connection = ConnectionFactory.GetConnection();
            return await connection.UpdateAsync(entity);
        }
    }
}

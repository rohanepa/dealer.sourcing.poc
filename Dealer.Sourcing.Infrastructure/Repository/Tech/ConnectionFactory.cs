using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;

namespace Dealer.Sourcing.Infrastructure.Repository.Tech
{
    public class ConnectionFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ConnectionFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDbConnection GetConnection()
        {
            var connection = _serviceProvider.GetRequiredService<IDbConnection>();
            return _serviceProvider.GetRequiredService<IDbConnection>();
        }
    }
}

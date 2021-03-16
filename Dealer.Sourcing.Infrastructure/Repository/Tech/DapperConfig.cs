using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace Dealer.Sourcing.Infrastructure.Repository.Tech
{
    public class DapperConfig
    {
        public static void Configure(IServiceCollection services)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddTransient<IDbConnection>(sp =>
                new NpgsqlConnection("Host=csndealersourcing.pgdb.csstg.com.au;Port=6432;Username=dealersourcing_admin;Password=0Hdpj5I2bTCR68D6ODdS;Database=csndealersourcing"));
            services.AddScoped<ConnectionFactory>();
        }
    }
}

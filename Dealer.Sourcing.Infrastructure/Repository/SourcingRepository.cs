using AutoMapper;
using Dapper;
using Dealer.Sourcing.Infrastructure.Models;
using Dealer.Sourcing.Infrastructure.Repository.Tech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Infrastructure.Repository
{
    public class SourcingRepository : Repository<Domain.Core.Sourcing>, ISourcingRepository
    {
        private readonly IMapper _mapper;

        public SourcingRepository(ConnectionFactory connectionFactory, IMapper mapper) : base(connectionFactory)
        {
            _mapper = mapper;
        }

        public async Task<Domain.Core.Sourcing> FindById(Guid sourcingId)
        {
            var sourcingEntity = await Get<Models.Sourcing>(sourcingId);

            return _mapper.Map<Models.Sourcing, Domain.Core.Sourcing>(sourcingEntity);
        }

        public async Task<Domain.Core.Sourcing> GetAggregate(Guid sourcingId)
        {
            var sourcingSql = $"SELECT * FROM Sourcing WHERE Id = '{sourcingId}';";
            var appraisalSql = $"SELECT * FROM Appraisal WHERE source_id = '{sourcingId}';";

            using var connection = ConnectionFactory.GetConnection();
            using var results = await connection.QueryMultipleAsync($"{sourcingSql} {appraisalSql}");

            var sourcing = (await results.ReadAsync<Models.Sourcing>()).SingleOrDefault();
            if (sourcing == null) return null;
            var appraisals = (await results.ReadAsync<Appraisal>()).ToList();
            sourcing.Appraisals = appraisals;
            return _mapper.Map<Models.Sourcing, Domain.Core.Sourcing>(sourcing); ;
        }

        public async Task CreateSourcing(Domain.Core.Sourcing sourcing)
        {
            //Map to db entity
            var sourcingEntity = _mapper.Map<Domain.Core.Sourcing, Models.Sourcing>(sourcing);
            var appraisals = _mapper.Map<List<Domain.Core.Appraisal>, List<Appraisal>>(sourcing.Appraisals.AsList());

            await Insert(sourcingEntity);
            foreach (var appraisal in appraisals)
            {
                await Insert(appraisal);
            }
        }
    }
}

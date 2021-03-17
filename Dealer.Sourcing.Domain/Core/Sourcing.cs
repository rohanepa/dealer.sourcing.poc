using Dealer.Sourcing.Domain.Tech;
using System;
using System.Collections.Generic;

namespace Dealer.Sourcing.Domain.Core
{
    public class Sourcing : Entity, IAggregateRoot
    {
        private readonly List<Appraisal> _appraisals;

        public Guid SpecId { get; private set; }
        public Guid DealerId { get; private set; }
        public IReadOnlyCollection<Appraisal> Appraisals => _appraisals;

        public Sourcing()
        {
            _appraisals ??= new List<Appraisal>();
        }

        public void SetDealerOwnership(Guid dealerId)
        {
            DealerId = dealerId;
        }

        public void HasSpecifications(Guid specId)
        {
            SpecId = specId;
        }

        public void AddAppraisal(decimal valuation)
        {
            var appraisal = Appraisal.Create(valuation);
            _appraisals.Add(appraisal);
        }

        public static Sourcing Create()
        {
            return new Sourcing { Id = Guid.NewGuid() };
        }
    }
}

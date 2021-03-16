using Dealer.Sourcing.Domain.Tech;

namespace Dealer.Sourcing.Domain.Core
{
    public class Appraisal : Entity
    {
        public decimal Valuation { get; private set; }

        public static Appraisal Create(decimal valuation)
        {
            return new Appraisal { Valuation = valuation };
        }
    }
}

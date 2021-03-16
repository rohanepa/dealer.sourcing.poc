using AutoMapper;
using Dealer.Sourcing.Domain.Core;

namespace Dealer.Sourcing.Infrastructure.Mappers
{
    public class SourcingMapper : Profile
    {
        protected SourcingMapper()
        {
            ShouldMapField = fieldInfo => true;

            CreateMap<Appraisal, Models.Appraisal>().ReverseMap();
            CreateMap<Domain.Core.Sourcing, Models.Sourcing>().ReverseMap();
        }
    }
}

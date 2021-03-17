using AutoMapper;
using Dealer.Sourcing.Domain.Core;

namespace Dealer.Sourcing.Infrastructure.Mappers
{
    public class SourcingMapper : Profile
    {
        public SourcingMapper()
        {
            ShouldMapField = fieldInfo => true;

            CreateMap<Appraisal, Models.Appraisal>().ReverseMap();
            CreateMap<Models.Sourcing, Domain.Core.Sourcing>()
                .ForMember(dst => dst.Appraisals, opt => opt.MapFrom(src => src.Appraisals))
                .ReverseMap();
        }
    }
}

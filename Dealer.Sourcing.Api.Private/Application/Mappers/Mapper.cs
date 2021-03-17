using AutoMapper;
using Dealer.Sourcing.Api.Private.Application.Dtos;

namespace Dealer.Sourcing.Api.Private.Application.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Domain.Core.Sourcing, SourcingDto>();
        }
    }
}

using AutoMapper;
using Dealer.Sourcing.Api.Private.Application.Dtos;
using Dealer.Sourcing.Infrastructure.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Api.Private.Application.Queries
{
    public class GetSourcingRecordByIdQuery : IRequest<SourcingDto>
    {
        public Guid SourcingId { get; }

        public GetSourcingRecordByIdQuery(Guid sourcingId)
        {
            SourcingId = sourcingId;
        }
    }

    public class GetSourcingRecordByIdQueryHandler : IRequestHandler<GetSourcingRecordByIdQuery, SourcingDto>
    {
        private readonly ISourcingRepository _sourcingRepository;
        private IMapper _mapper;

        public GetSourcingRecordByIdQueryHandler(ISourcingRepository sourcingRepository, IMapper mapper)
        {
            _sourcingRepository = sourcingRepository;
            _mapper = mapper;
        }

        public async Task<SourcingDto> Handle(GetSourcingRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var sourcing = await _sourcingRepository.FindById(request.SourcingId);
            var sourcingAggregate = await _sourcingRepository.GetAggregate(request.SourcingId);
            return _mapper.Map<Domain.Core.Sourcing, SourcingDto>(sourcingAggregate);
        }
    }
}

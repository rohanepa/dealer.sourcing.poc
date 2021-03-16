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

        public GetSourcingRecordByIdQueryHandler(ISourcingRepository sourcingRepository)
        {
            _sourcingRepository = sourcingRepository;
        }

        public async Task<SourcingDto> Handle(GetSourcingRecordByIdQuery request, CancellationToken cancellationToken)
        {
            await _sourcingRepository.FindById(request.SourcingId);
            return null;
        }
    }
}

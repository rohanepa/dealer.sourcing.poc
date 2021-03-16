using Dealer.Sourcing.Api.Private.Application.Dtos;
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
        public GetSourcingRecordByIdQueryHandler()
        {

        }

        public async Task<SourcingDto> Handle(GetSourcingRecordByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;

namespace Dealer.Sourcing.Api.Private.Application.Dtos
{
    public class SourcingDto
    {
        public Guid Id { get; set; }
        public Guid DealerId { get; set; }
        public Guid SpecId { get; set; }
    }
}

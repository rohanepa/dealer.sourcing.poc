using Dapper.Contrib.Extensions;
using System;

namespace Dealer.Sourcing.Infrastructure.Models
{
    [Table("Sourcing")]
    public class Sourcing
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DealerId { get; set; }
        public Guid SpecId { get; set; }
    }
}

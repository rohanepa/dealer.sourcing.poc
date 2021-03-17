using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dealer.Sourcing.Infrastructure.Models
{
    [Table("Sourcing")]
    public class Sourcing
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DealerId { get; set; }
        public Guid SpecId { get; set; }
        [Computed]
        public List<Appraisal> Appraisals { get; set; }
    }
}

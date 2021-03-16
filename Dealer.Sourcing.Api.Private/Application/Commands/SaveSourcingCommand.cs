using Dealer.Sourcing.Api.Private.Application.Tech.MediatR;
using Dealer.Sourcing.Api.Private.Application.Tech.Validation;
using System.Threading.Tasks;
using Dealer.Sourcing.Infrastructure.Repository;
using Dealer.Sourcing.Infrastructure.Repository.Tech;

namespace Dealer.Sourcing.Api.Private.Application.Commands
{
    public class SaveSourcingCommand : CommandRequest
    {
    }

    public class SaveSourcingCommandHandler : BaseCommandHandler<SaveSourcingCommand>
    {
       // private IRepository<Sourcing> _repository;
        private ISourcingRepository _sourcingRepository;
        public override async Task Validate(ValidationContext validationContext)
        {
        }

        public override async Task<Response> DoHandle()
        {
            return Response.Ok();
        }
    }
}

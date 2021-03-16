using Dealer.Sourcing.Api.Private.Application.Tech.MediatR;
using Dealer.Sourcing.Api.Private.Application.Tech.Validation;
using Dealer.Sourcing.Infrastructure.Repository;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Api.Private.Application.Commands
{
    public class SaveSourcingCommand : CommandRequest
    {
    }

    public class SaveSourcingCommandHandler : BaseCommandHandler<SaveSourcingCommand>
    {
        private ISourcingRepository _sourcingRepository;

        public SaveSourcingCommandHandler(ISourcingRepository sourcingRepository)
        {
            _sourcingRepository = sourcingRepository;
        }

        public override async Task Validate(ValidationContext validationContext)
        {
        }

        public override async Task<Response> DoHandle()
        {
            return Response.Ok();
        }
    }
}

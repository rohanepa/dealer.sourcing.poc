using Dealer.Sourcing.Api.Private.Application.Dtos;
using Dealer.Sourcing.Api.Private.Application.Tech.MediatR;
using Dealer.Sourcing.Api.Private.Application.Tech.Validation;
using Dealer.Sourcing.Api.Private.Application.Validators;
using Dealer.Sourcing.Infrastructure.Repository;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Api.Private.Application.Commands
{
    public class CreateSourcingCommand : CommandRequest
    {
        public CreateSourcingCommand(SourcingDto sourcing)
        {
            Sourcing = sourcing;
        }

        public SourcingDto Sourcing { get; }
    }

    public class CreateSourcingCommandHandler : BaseCommandHandler<CreateSourcingCommand>
    {
        private readonly ISourcingRepository _sourcingRepository;

        public CreateSourcingCommandHandler(ISourcingRepository sourcingRepository)
        {
            _sourcingRepository = sourcingRepository;
        }

        public override async Task Validate(ValidationContext validationContext)
        {
            await new CreateSourcingCommandValidator().ApplyValidationAsync(validationContext, Command);
        }

        public override async Task<Response> DoHandle()
        {
            //If the object creation is complex we can use builders for Aggregates to tackle the complexity
            var sourcing = Domain.Core.Sourcing.Create();
            sourcing.HasSpecifications(Command.Sourcing.SpecId);
            sourcing.SetDealerOwnership(Command.Sourcing.DealerId);
            sourcing.AddAppraisal(2000);

            await _sourcingRepository.CreateSourcing(sourcing);
            return Response.Ok();
        }
    }
}

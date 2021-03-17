using Dealer.Sourcing.Api.Private.Application.Commands;
using Dealer.Sourcing.Api.Private.Application.Tech.Validation;
using FluentValidation;

namespace Dealer.Sourcing.Api.Private.Application.Validators
{
    public class CreateSourcingCommandValidator : BaseValidator<CreateSourcingCommand>
    {
        public CreateSourcingCommandValidator()
        {
            RuleFor(s => s.Sourcing.DealerId).NotEmpty();
        }
    }
}

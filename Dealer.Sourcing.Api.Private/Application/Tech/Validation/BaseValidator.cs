using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Api.Private.Application.Tech.Validation
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected BaseValidator()
        {
            ValidatorOptions.Global.PropertyNameResolver = (type, member, lambda) => member?.Name;
        }

        public async Task ApplyValidationAsync(ValidationContext validationContext, T command)
        {
            var result = await ValidateAsync(command);

            if (result.IsValid)
                return;

            result.Errors.ToList()
                .ForEach(error => validationContext.AddError(error.PropertyName, error.ErrorMessage));
        }
    }
}

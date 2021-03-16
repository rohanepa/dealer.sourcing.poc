using System.Collections.Generic;
using System.Linq;

namespace Dealer.Sourcing.Api.Private.Application.Tech.Validation
{
    public class ValidationContext
    {
        public bool HasErrors => ValidationErrors != null && ValidationErrors.Any();
        public IList<ValidationError> ValidationErrors { get; private set; }

        public void AddError(string memberName, string errorMessage)
        {
            ValidationErrors ??= new List<ValidationError>();

            ValidationErrors.Add(new ValidationError(memberName, errorMessage));
        }
    }
}

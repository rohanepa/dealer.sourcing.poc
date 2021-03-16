using Dealer.Sourcing.Api.Private.Application.Tech.Validation;
using System.Collections.Generic;

namespace Dealer.Sourcing.Api.Private.Application.Tech.MediatR
{
    public interface IResponse
    {
        IList<ValidationError> ValidationResults { get; set; }
        bool Success { get; }
        TResult Result<TResult>() where TResult : class;
        void SetResult<TResult>(TResult result) where TResult : class;
    }
}

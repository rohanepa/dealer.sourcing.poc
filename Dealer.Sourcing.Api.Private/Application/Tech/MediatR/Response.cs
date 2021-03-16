using Dealer.Sourcing.Api.Private.Application.Tech.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Dealer.Sourcing.Api.Private.Application.Tech.MediatR
{
    public class Response : IResponse
    {
        public IList<ValidationError> ValidationResults { get; set; }

        public bool Success => ValidationResults == null || !ValidationResults.Any();

        protected object ResponseResult { get; private set; }

        public Response()
        {
            ValidationResults = new List<ValidationError>();
        }

        public Response(IList<ValidationError> validationResults)
        {
            ValidationResults = validationResults;
        }

        public TResult Result<TResult>() where TResult : class
        {
            return ResponseResult as TResult;
        }

        public void SetResult<TResult>(TResult result) where TResult : class
        {
            ResponseResult = result;
        }

        public static Response Ok()
        {
            return new Response();
        }
    }
}

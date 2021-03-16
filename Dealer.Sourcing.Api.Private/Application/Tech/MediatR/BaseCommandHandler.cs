using Dealer.Sourcing.Api.Private.Application.Tech.Validation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Dealer.Sourcing.Api.Private.Application.Tech.MediatR
{
    public abstract class BaseCommandHandler<TCommand>
        : IRequestHandler<TCommand, IResponse> where TCommand : CommandRequest
    {
        protected TCommand Command { get; private set; }

        public virtual async Task<IResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            Command = request;

            var validationContext = new ValidationContext();

            await Validate(validationContext);
            if (validationContext.HasErrors)
                return new Response(validationContext.ValidationErrors);

            using var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
                TransactionScopeAsyncFlowOption.Enabled);
            var result = await DoHandle();
            transaction.Complete();

            return !result.Success ? new Response(result.ValidationResults) : result;
        }

        public abstract Task Validate(ValidationContext validationContext);

        public abstract Task<Response> DoHandle();
    }
}

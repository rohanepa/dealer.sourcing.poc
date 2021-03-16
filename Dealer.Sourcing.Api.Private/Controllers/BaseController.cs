using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dealer.Sourcing.Api.Private.Controllers
{

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; }
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}

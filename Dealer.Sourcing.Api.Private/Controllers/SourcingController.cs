using Dealer.Sourcing.Api.Private.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dealer.Sourcing.Api.Private.Controllers
{
    [Route("api/[controller]")]
    public class SourcingController : BaseController
    {
        public SourcingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var result = await Mediator.Send(new SaveSourcingCommand());
            return Ok();
        }
    }
}

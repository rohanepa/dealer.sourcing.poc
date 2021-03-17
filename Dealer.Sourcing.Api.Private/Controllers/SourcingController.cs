using Dealer.Sourcing.Api.Private.Application.Commands;
using Dealer.Sourcing.Api.Private.Application.Dtos;
using Dealer.Sourcing.Api.Private.Application.Queries;
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
            return Ok(await Mediator.Send(new GetSourcingRecordByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(SourcingDto sourcing)
        {
            await Mediator.Send(new CreateSourcingCommand(sourcing));
            return Ok();
        }
    }
}

using Footwear.Application.Mediator.Commands.BasketCommands;
using Footwear.Application.Mediator.Queries.BasketQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var result = await _mediator.Send(new GetBasketQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var result = await _mediator.Send(new DeleteBasketCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasket(UpdateBasketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(int id)
        {
            var result = await _mediator.Send(new GetBasketByIdQuery(id));
            return Ok(result);
        }
    }
}

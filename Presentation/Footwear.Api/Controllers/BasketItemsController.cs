using Footwear.Application.Mediator.Commands.BasketItemCommands;
using Footwear.Application.Mediator.Queries.BasketItemQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasketItem()
        {
            var result = await _mediator.Send(new GetBasketItemQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBasketItem(CreateBasketItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketItem(int id)
        {
            var result = await _mediator.Send(new DeleteBasketItemCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasketItem(UpdateBasketItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketItemById(int id)
        {
            var result = await _mediator.Send(new GetBasketItemByIdQuery(id));
            return Ok(result);
        }
    }
}

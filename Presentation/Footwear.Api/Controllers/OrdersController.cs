using Footwear.Application.Base;
using Footwear.Application.Mediator.Commands.AboutCommands;
using Footwear.Application.Mediator.Commands.OrderCommands;
using Footwear.Application.Mediator.Queries.AboutQueries;
using Footwear.Application.Mediator.Queries.OrderQueries;
using Footwear.Application.Mediator.Results.OrderResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand model)
    {       
        var result = await _mediator.Send(model);
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
       var result = await _mediator.Send(new GetOrderQuery());
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var result = await _mediator.Send(new DeleteOrderCommand(id));
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery(id));
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

using Footwear.Application.Mediator.Commands.AboutCommands;
using Footwear.Application.Mediator.Commands.OrderCommands;
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
}

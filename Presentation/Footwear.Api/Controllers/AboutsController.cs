using Footwear.Application.Mediator.Commands.AboutCommands;
using Footwear.Application.Mediator.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreatetAbout(CreateAboutCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var result = await _mediator.Send(new DeleteAboutCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var result = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            var result = await _mediator.Send(new GetAboutQuery());
            return Ok(result);
        }
    }
}

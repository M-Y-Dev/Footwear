using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using Footwear.Application.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/social-medias")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var result = await _mediator.Send(new DeleteSocialMediaCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var result = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetSocialMedias()
        {
            var result = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(result);
        }
    }
}

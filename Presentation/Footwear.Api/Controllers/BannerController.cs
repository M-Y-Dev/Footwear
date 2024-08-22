using Footwear.Application.Mediator.Commands.BannerCommands;
using Footwear.Application.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannerController ( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner ( CreateBannerCommand model )
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner ( int id )
        {
            var result = await _mediator.Send(new DeleteBannerCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner ( UpdateBannerCommand model )
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById ( int id )
        {
            var result = await _mediator.Send(new GetBannerByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBanner ()
        {
            var result = await _mediator.Send(new GetBannerQuery());
            return Ok(result);
        }
    }
}


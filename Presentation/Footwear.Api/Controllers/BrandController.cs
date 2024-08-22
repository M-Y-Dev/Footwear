using Footwear.Application.Mediator.Commands.BrandCommand;
using Footwear.Application.Mediator.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController ( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand ( CreateBrandCommand model )
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand ( int id )
        {
            var result = await _mediator.Send(new DeleteBrandCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand ( UpdateBrandCommand model )
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById ( int id )
        {
            var result = await _mediator.Send(new GetBrandByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBrand ()
        {
            var result = await _mediator.Send(new GetBrandQuery());
            return Ok(result);
        }
    }
}


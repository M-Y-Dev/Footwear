using Footwear.Application.Mediator.Commands.CategoryCommands;
using Footwear.Application.Mediator.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var result = await _mediator.Send(new GetCategoryQuery());
            return Ok(result);
        }
    }
}

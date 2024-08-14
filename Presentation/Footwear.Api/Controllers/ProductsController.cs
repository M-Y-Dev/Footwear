using Footwear.Application.Mediator.Commands.ProductCommands;
using Footwear.Application.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result = await _mediator.Send(new GetProductQuery());
            return Ok(result);
        }

        [HttpGet("GetProductWithInclude")]
        public async Task<IActionResult> GetProductWithInclude()
        {
            var result = await _mediator.Send(new GetProductWithCategoryIncludeQuery());
            return Ok(result);
        }
        [HttpGet("GetProductFilterAndInclude")]
        public async Task<IActionResult> GetProductFilterAndInclude()
        {
            var result = await _mediator.Send(new GetProductFilterAndIncludeQuery());
            return Ok(result);
        }
        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var result = await _mediator.Send(new GetProductCountQuery());
            return Ok(result);
        }
        [HttpGet("GetProductFilterCount")]
        public async Task<IActionResult> GetProductFilterCount()
        {
            var result = await _mediator.Send(new GetProductFilterCountQuery());
            return Ok(result);
        }

    }
}

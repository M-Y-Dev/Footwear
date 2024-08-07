using Footwear.Application.Mediator.Commands.CommentCommands;
using Footwear.Application.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _mediator.Send(new DeleteCommentCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var result = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetComment()
        {
            var result = await _mediator.Send(new GetCommentQuery());
            return Ok(result);
        }
    }
}

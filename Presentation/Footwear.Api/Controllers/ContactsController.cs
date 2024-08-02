using Footwear.Application.Mediator.Commands.ContactCommands;
using Footwear.Application.Mediator.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _mediator.Send(new DeleteContactCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = await _mediator.Send(new GetContactByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            var result = await _mediator.Send(new GetContactQuery());
            return Ok(result);
        }
    }
}

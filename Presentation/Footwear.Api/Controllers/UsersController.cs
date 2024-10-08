﻿using AutoMapper;
using Footwear.Application.Mediator.Commands.UserCommands;
using Footwear.Application.Mediator.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Footwear.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var values = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var values = await _mediator.Send(command);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var values = await _mediator.Send(command);
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var values = await _mediator.Send(new DeleteUserCommand(id));
            return Ok(values);

        }

        [HttpGet("GetUserWithRole")]
        public async Task<IActionResult> GetUserWithRole()
        {
            var values = await _mediator.Send(new GetAppUserListWithRoleQuery());
            return Ok(values);
        }
    }
}

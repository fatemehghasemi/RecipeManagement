using Application.Recipes.Queries;
using Application.User.Commands;
using Application.User.Queries;
using Application.User.ResponseModel;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> Get([FromQuery] string? nameFilter)
    {
        var query = new GetUserListQuery { };
        var users = await _mediator.Send(query);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetById(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var user = await _mediator.Send(query);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Post([FromBody] UserCreateCommand command)
    {
        var user = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = user.Data.Id }, user);
    }

    [HttpPut]
    public async Task<ActionResult<Result<UserResponse>>> Put([FromBody] UserUpdateCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess) return NotFound(result);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new UserDeleteCommand(id);
        var deleted = await _mediator.Send(command);
        return NoContent();
    }
}

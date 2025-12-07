using Application.User.Commands;
using Application.User.ResponseModel;
using Application.UserRecipeInteraction.Commands;
using Application.UserRecipeInteraction.Queries;
using Application.UserRecipeInteraction.ResponseModel;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRecipeInteractionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserRecipeInteractionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetByUserIDAsync([FromQuery] Guid UserID)
        {
            var query = new GetUserRecipeInteractionByIdCommand() { UserId=UserID};
            var userRecipeInteraction = await _mediator.Send(query);
            return Ok(userRecipeInteraction);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRecipeInteraction([FromBody] UserRecipeInteractionCreateCommand command)
        {
            var userRecipeInteraction = await _mediator.Send(command);
            return Ok(userRecipeInteraction);
        }

        [HttpPut]
        public async Task<ActionResult<Result<UserRecipeInteractionResponse>>> Put([FromBody] UserRecipeInteractionUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

using Application.Recipe.ResponseModels;
using Application.Recipes.Commands;
using Application.Recipes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecipeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeResponse>>> Get([FromQuery] string? tag)
    {
        var query = new GetUserQuery { Tag = tag };
        var recipes = await _mediator.Send(query);
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeResponse>> GetById(Guid id)
    {
        var query = new GetUserQuery();
        var recipes = await _mediator.Send(query);
        var recipe = recipes.FirstOrDefault(r => r.Id == id);
        if (recipe == null) return NotFound();
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeResponse>> Post([FromBody] AddRecipeCommand command)
    {
        var recipe = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpPut]
    public async Task<ActionResult<RecipeResponse>> Put([FromBody] UpdateRecipeCommand command)
    {
        var recipe = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteRecipeCommand(id);
        var result = await _mediator.Send(command);

        if (!result) return NotFound();
        return NoContent();
    }
}

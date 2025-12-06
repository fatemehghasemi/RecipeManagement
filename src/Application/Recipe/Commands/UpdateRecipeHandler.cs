using Application.Recipe.ResponseModels;
using Application.Recipes.Commands;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Recipes.Handlers.CommandHandlers;

public class UpdateRecipeHandler : IRequestHandler<UpdateRecipeCommand, RecipeResponse>
{
    private readonly IRecipeRepository _recipeRepository;

    public UpdateRecipeHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<RecipeResponse> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = new Domain.Entities.Recipe
        {
            Id = request.Id,
            Title = request.Title,
            Calories = request.Calories,
            Protein = request.Protein,
            Fat = request.Fat,
            Carbs = request.Carbs,
            Tags = request.Tags
        };

        await _recipeRepository.UpdateAsync(recipe);

        return recipe.Adapt<RecipeResponse>();
    }
}

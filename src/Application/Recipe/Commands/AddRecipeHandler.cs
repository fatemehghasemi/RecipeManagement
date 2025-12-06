using Application.Recipe.ResponseModels;
using Application.Recipes.Commands;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Recipes.Handlers.CommandHandlers;

public class AddRecipeHandler : IRequestHandler<AddRecipeCommand, RecipeResponse>
{
    private readonly IRecipeRepository _recipeRepository;

    public AddRecipeHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<RecipeResponse> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = new Domain.Entities.Recipe
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Calories = request.Calories,
            Protein = request.Protein,
            Fat = request.Fat,
            Carbs = request.Carbs,
            Tags = request.Tags
        };

        await _recipeRepository.AddAsync(recipe);

        return recipe.Adapt<RecipeResponse>();
    }
}

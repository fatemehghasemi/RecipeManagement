using Application.Recipes.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Recipes.Handlers.CommandHandlers;

public class DeleteRecipeHandler : IRequestHandler<DeleteRecipeCommand, bool>
{
    private readonly IRecipeRepository _recipeRepository;

    public DeleteRecipeHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<bool> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);
        if (recipe == null)
            return false;

        await _recipeRepository.DeleteAsync(recipe);
        return true;
    }
}

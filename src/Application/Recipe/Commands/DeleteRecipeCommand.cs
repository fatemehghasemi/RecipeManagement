using MediatR;

namespace Application.Recipes.Commands;

public class DeleteRecipeCommand : IRequest<bool>
{
    public Guid RecipeId { get; set; }

    public DeleteRecipeCommand(Guid recipeId)
    {
        RecipeId = recipeId;
    }
}

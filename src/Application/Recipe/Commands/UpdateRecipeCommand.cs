using Application.Recipe.ResponseModels;
using MediatR;

namespace Application.Recipes.Commands;

public class UpdateRecipeCommand : AddRecipeCommand, IRequest<RecipeResponse>
{
    public Guid Id { get; set; }
}

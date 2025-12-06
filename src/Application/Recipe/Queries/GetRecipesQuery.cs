using Application.Recipe.ResponseModels;
using MediatR;

namespace Application.Recipes.Queries;

public class GetRecipesQuery : IRequest<IEnumerable<RecipeResponse>>
{
    public string? Tag { get; set; }
}

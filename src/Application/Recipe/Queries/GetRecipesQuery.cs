using Application.Recipe.ResponseModels;
using MediatR;

namespace Application.Recipes.Queries;

public class GetUserQuery : IRequest<IEnumerable<RecipeResponse>>
{
    public string? Tag { get; set; }
}

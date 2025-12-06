using Application.Recipe.ResponseModels;
using Application.Recipes.Queries;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Recipes.Handlers.QueryHandlers;

public class GetUserHandler : IRequestHandler<GetUserQuery, IEnumerable<RecipeResponse>>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetUserHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<RecipeResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(request.Tag))
        {
            recipes = recipes.Where(r => r.Tags.Contains(request.Tag, StringComparison.OrdinalIgnoreCase));
        }

        return recipes.ToList().Adapt<List<RecipeResponse>>();
    }
}

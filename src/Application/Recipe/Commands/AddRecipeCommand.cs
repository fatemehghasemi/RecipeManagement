using Application.Recipe.ResponseModels;
using MediatR;

namespace Application.Recipes.Commands;

public class AddRecipeCommand : IRequest<RecipeResponse>
{
    public string Title { get; set; } = null!;
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }
    public int Carbs { get; set; }
    public string Tags { get; set; } = null!;
}

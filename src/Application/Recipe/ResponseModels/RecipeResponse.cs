namespace Application.Recipe.ResponseModels;
public class RecipeResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }
    public int Carbs { get; set; }
    public string Tags { get; set; } = null!;
}

using Domain.Common;

namespace Domain.Entities;
public record Recipe : EntityBase
{
    public string Title { get; set; } = string.Empty;

    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }
    public int Carbs { get; set; }
    public string Tags { get; set; } = string.Empty;
}


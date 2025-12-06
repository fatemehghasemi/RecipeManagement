using Domain.Common;

namespace Domain.Entities;
public record UserRecipeInteraction : EntityBase
{
    public string Action { get; set; } = string.Empty;  //"Liked","Disliked", "Saved"
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public Guid UserId { get; set; }
    public Guid RecipeId { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual Recipe Recipe { get; set; } = null!;
}


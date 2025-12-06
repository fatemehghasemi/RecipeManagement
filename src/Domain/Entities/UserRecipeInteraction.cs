using Domain.Common;

namespace Domain.Entities;
public record UserRecipeInteraction : EntityBase
{
    public string Action { get; set; } = string.Empty;  // "Viewed", "Liked", "Saved"
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public virtual User User { get; set; } = null!;
    public virtual Recipe Recipe { get; set; } = null!;
}


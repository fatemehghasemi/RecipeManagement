using Domain.Common;

namespace Domain.Entities;
public record User : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public string DietaryPreference { get; set; } = string.Empty;
    public string HealthGoal { get; set; } = string.Empty;

    public void UpdatePreferences(string dietaryPreference, string healthGoal)
    {
        DietaryPreference = dietaryPreference;
        HealthGoal = healthGoal;
    }
}

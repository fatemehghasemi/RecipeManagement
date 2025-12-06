using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRecipeInteractionRepository
{
    Task AddInteractionAsync(UserRecipeInteraction interaction);
    Task<IEnumerable<UserRecipeInteraction>> GetByUserIdAsync(long userId);
    Task SaveChangesAsync();
}

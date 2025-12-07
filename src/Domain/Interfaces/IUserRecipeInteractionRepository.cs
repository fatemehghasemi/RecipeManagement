using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRecipeInteractionRepository
{
    Task AddAsync(UserRecipeInteraction interaction);
    Task<IEnumerable<UserRecipeInteraction>> GetByUserIdAsync(Guid userId);
    Task UpdateAsync(UserRecipeInteraction interaction);

}

using Domain.Entities;

namespace Domain.Interfaces;

public interface IRecipeRepository
{
    Task<Recipe?> GetByIdAsync(Guid id);
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task AddAsync(Recipe recipe);
    Task UpdateAsync(Recipe recipe);
}

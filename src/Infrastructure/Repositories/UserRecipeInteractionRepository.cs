using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class UserRecipeInteractionRepository : IUserRecipeInteractionRepository
{
    private readonly RecipeDBContext _context;

    public UserRecipeInteractionRepository(RecipeDBContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserRecipeInteraction interaction)
    {
        await _context.UserRecipeInteractions.AddAsync(interaction);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserRecipeInteraction>> GetByUserIdAsync(Guid userId)
    {
        return await _context.UserRecipeInteractions
            .AsNoTracking()
            .Where(i => i.UserId == userId)
            .ToListAsync();
    }
}

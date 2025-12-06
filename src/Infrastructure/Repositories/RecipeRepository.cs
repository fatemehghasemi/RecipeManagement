using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class RecipeRepository : IRecipeRepository
{
    private readonly RecipeDBContext _context;

    public RecipeRepository(RecipeDBContext context)
    {
        _context = context;
    }
    public async Task<Recipe?> GetByIdAsync(Guid id)
    {
        return await _context.Recipes
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await _context.Recipes
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task AddAsync(Recipe recipe)
    {
        await _context.Recipes.AddAsync(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }
}

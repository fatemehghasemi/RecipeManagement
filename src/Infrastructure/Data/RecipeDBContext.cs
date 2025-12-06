using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class RecipeDBContext : DbContext
{
    public RecipeDBContext(DbContextOptions<RecipeDBContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users => Set<User>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<UserRecipeInteraction> UserRecipeInteractions => Set<UserRecipeInteraction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

using Application;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RecipeDBContext>(options =>
                 options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnectionString"),
                        sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure") // مشخص کردن پروژه مایگریشن‌ها
         ));

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddApplication();
            return services;
        }
    }
}

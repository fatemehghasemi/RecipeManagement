using Application.Behaviours;
using Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Recipe.Queries.GetByTagQueriesCommandHandler).Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddValidatorsFromAssemblyContaining<AddRecipeValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}

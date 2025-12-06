using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

public static class ExceptionHandlerExtensions
{
    public static void UseResultExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerFeature>();
                var ex = feature?.Error;

                context.Response.ContentType = "application/json";

                string jsonResponse;

                if (ex is ValidationException valEx)
                {
                    context.Response.StatusCode = 400;

                    var messages = valEx.Errors.Select(e => e.ErrorMessage).ToList();
                    var msg = string.Join(" | ", messages);

                    jsonResponse = JsonSerializer.Serialize(AppResult.Fail(msg, "VALIDATION_ERROR"));
                }
                else
                {
                    context.Response.StatusCode = 500;
                    jsonResponse = JsonSerializer.Serialize(AppResult.Fail("An unexpected error occurred.", "SERVER_ERROR"));
                }

                await context.Response.WriteAsync(jsonResponse);
            });
        });
    }
}

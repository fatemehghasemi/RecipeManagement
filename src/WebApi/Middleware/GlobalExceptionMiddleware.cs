using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

public static class GlobalExceptionMiddleware
{
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
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

                    jsonResponse = JsonSerializer.Serialize(Result.Fail(msg, "VALIDATION_ERROR"));
                }
                else
                {
                    context.Response.StatusCode = 500;
                    jsonResponse = JsonSerializer.Serialize(Result.Fail("An unexpected error occurred.", "SERVER_ERROR"));
                }

                await context.Response.WriteAsync(jsonResponse);
            });
        });
    }
}

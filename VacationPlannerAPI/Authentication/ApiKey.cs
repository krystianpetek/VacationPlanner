using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VacationPlannerAPI.Authentication;

[AttributeUsage(AttributeTargets.Class)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter
{
    private const string APIKEYNAME = "ApiKey"; // appsettings.json

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401, //Unauthorized
                Content = "Klucz API nie został dostarczony."
            };
            return;
        }

        var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        var apiKey = appSettings.GetValue<string>(APIKEYNAME);

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401, //Unauthorized
                Content = "Klucz API jest nieprawidłowy."
            };
            return;
        }

        await next();
    }
}
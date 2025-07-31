using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ecommerce.API.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddlware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddlware> _logger;

    public ExceptionHandlingMiddlware(RequestDelegate next,ILogger<ExceptionHandlingMiddlware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex) 
        {
            //Log the Exception type and message
            _logger.LogError($"{ex.GetType().ToString()}:{ex.Message}");
            
            if(ex.InnerException is not null)
            {
                _logger.LogError($"{ex.InnerException.GetType()}:{ex.InnerException.Message}");
            }
            httpContext.Response.StatusCode = 500; //Internal Server Error
            await httpContext.Response.WriteAsJsonAsync(new {Message =ex.Message,Type=ex.GetType().ToString()});
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlwareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddlware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddlware>();
    }
}

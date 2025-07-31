using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the dependency Injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //To DO: Add services to IOC container
        //Core services often include data access, caching and other low level components
        services.AddTransient<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidation>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}

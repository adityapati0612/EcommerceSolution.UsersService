using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Dbcontext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency Injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //To DO: Add services to IOC container
        //Infrastructure services often include data access, caching and other low level components

        services.AddTransient<IUserRepository,UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}

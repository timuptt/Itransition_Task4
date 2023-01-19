using AccountManagement.Infrastructure.Helpers;
using AccountManagement.Infrastructure.Identity;
using AccountManagement.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationIdentityContext>(options =>
            options.UseNpgsql(ConnectionHelper.GetConnectionString(configuration)));

        return services;
    }
}
using AccountManagement.Infrastructure.Helpers;
using AccountManagement.Infrastructure.Identity;
using AccountManagement.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace AccountManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresIdentity") ??
                               throw new InvalidOperationException("Connection string 'PostgresIdentity' not found.");
        services.AddDbContext<ApplicationIdentityContext>(options =>
            options.UseNpgsql(ConnectionHelper.BuildConnectionString(connectionString)));

        return services;
    }
}
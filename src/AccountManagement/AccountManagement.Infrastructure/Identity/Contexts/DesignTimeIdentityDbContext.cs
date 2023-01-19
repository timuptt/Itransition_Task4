using AccountManagement.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AccountManagement.Infrastructure.Identity.Contexts;

public class DesignTimeIdentityDbContext : IDesignTimeDbContextFactory<ApplicationIdentityContext>
{
    public ApplicationIdentityContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder() as IConfigurationBuilder;
        configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
        IConfigurationRoot configuration = configurationBuilder.Build();

        var connectionString = configuration.GetConnectionString("PostgresIdentity");

        DbContextOptionsBuilder<ApplicationIdentityContext> builder = new();
        builder.UseNpgsql(ConnectionHelper.BuildConnectionString(connectionString));

        return new (builder.Options);
    }
}
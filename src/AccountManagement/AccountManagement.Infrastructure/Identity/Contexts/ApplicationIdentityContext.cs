using AccountManagement.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.Identity.Contexts;

public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    protected sealed override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetToDateTimeUtcConverter>();
    }
}
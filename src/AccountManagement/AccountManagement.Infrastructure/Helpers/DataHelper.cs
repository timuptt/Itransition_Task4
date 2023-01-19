using AccountManagement.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AccountManagement.Infrastructure.Helpers;

public static class DataHelper
{
    public static async Task MigrateDataAsync(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ApplicationIdentityContext>();

        await context.Database.MigrateAsync();
    }
}
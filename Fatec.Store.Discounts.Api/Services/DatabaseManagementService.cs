using Fatec.Store.Discounts.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Discounts.Api.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            serviceScope?.ServiceProvider?.GetService<AppDbContext>()?.Database?.Migrate();
        }
    }
}

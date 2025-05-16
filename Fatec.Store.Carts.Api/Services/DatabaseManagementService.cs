using Fatec.Store.Carts.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Carts.Api.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            serviceScope?.ServiceProvider?.GetService<AppDbContext>()?.Database?.Migrate();
        }
    }
}

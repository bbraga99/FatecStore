using Fatec.Store.Carts.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Carts.Api.Service
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

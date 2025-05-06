using LojaFatec.CartApi.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaFatec.CartApi.Service
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

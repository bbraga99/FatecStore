using LojaFatec.ProductApi.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaFatec.ProductApi.Services
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

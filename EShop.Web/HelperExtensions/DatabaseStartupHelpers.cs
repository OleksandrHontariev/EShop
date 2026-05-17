using EShop.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using EShop.ServiceLayer.DatabaseServices;

namespace EShop.Web.HelperExtensions
{
    public static class DatabaseStartupHelpers
    {
        public static async Task<IHost> SetupDatabaseAsync(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var env = services.GetRequiredService<IWebHostEnvironment>();
                var context = services.GetRequiredService<EfDbContext>();

                try
                {
                    await context.SeedDatabaseIfNoProductsAsync(env.WebRootPath);
                } catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while creating/migrating or seeding the database.");

                    throw;
                }
            }
            return webHost;
        }
    }
}

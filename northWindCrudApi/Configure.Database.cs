using Microsoft.EntityFrameworkCore;
using northWindCrudApi.Data.Data;

[assembly: HostingStartup(typeof(northWindCrudApi.ConfigureDatabase))]

namespace northWindCrudApi;

public class ConfigureDatabase: IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(
            (context, services) =>
            {
                // connection string from appsettings.json
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<ApplicationDbContext>(
                    options =>
                    {
                        options.UseSqlServer(connectionString)
                            .EnableDetailedErrors();
                    });
                Console.WriteLine("Hello SQL Server");
            });
}

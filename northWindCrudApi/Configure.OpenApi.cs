[assembly: HostingStartup((typeof(northWindCrudApi.ConfigureOpenApi)))]

namespace northWindCrudApi;

public class ConfigureOpenApi: IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) => {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            if (context.HostingEnvironment.IsDevelopment())
            {
                services.AddTransient<IStartupFilter, StartupFilter>();
            }

            Console.WriteLine("Hello Open API");
        });

    public class StartupFilter : IStartupFilter
    {
        // Configure the HTTP request pipeline.
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            next(app);
        };
    }
}

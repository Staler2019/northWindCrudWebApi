using northWindCrudApi.Business.IServices;
using northWindCrudApi.Business.Services;
using northWindCrudApi.Data.IRespositories;
using northWindCrudApi.Data.IRespositories.Base;
using northWindCrudApi.Data.Repositories;
using northWindCrudApi.Data.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

// services
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IHelloService, HelloService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using northWindCrudApi.Business.DTOs;
using northWindCrudApi.Business.Enums;
using northWindCrudApi.Business.IServices;
using northWindCrudApi.Business.Services;
using northWindCrudApi.Data.Data;
using northWindCrudApi.Data.IRespositories;
using northWindCrudApi.Data.IRespositories.Base;
using northWindCrudApi.Data.Repositories;
using northWindCrudApi.Data.Repositories.Base;

namespace northWindCrudApi.Test;

public class RegionFixture
{
    public IServiceProvider ServiceProvider { get; }

    public RegionFixture()
    {
        var services = new ServiceCollection();
        var connectionString = "server=localhost;Database=NorthWind;MultipleActiveResultSets=True;TrustServerCertificate=True;User=SA;password=Root.0000";

        services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseSqlServer(connectionString)
                    .EnableDetailedErrors();
            });

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IRegionRepository, RegionRepository>();

        services.AddScoped<IRegionService, RegionService>();
        ServiceProvider = services.BuildServiceProvider();
    }
}

public class RegionServiceTest(RegionFixture fixture) : IClassFixture<RegionFixture>
{
    private readonly IRegionService _service =
        fixture.ServiceProvider.GetRequiredService<IRegionService>();


    [Fact]
    public async Task CreateRegion()
    {
        // Arrange
        var region = new CreateRegionRequestDto()
        {
            RegionId = 0, // o only valid for test
            RegionDescription = "Test Region"
        };

        // Act
        var result = await _service.CreateRegion(region);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(region.RegionId, result.RegionId);
        Assert.Equal(region.RegionDescription, result.RegionDescription);
    }

    [Fact]
    public async Task GetRegions()
    {
        // Act
        var result = await _service.GetRegions();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.IsAssignableFrom<IEnumerable<RegionDto>>(result);
    }

    [Fact]
    public async Task UpdateRegionDescription()
    {
        // Arrange
        var region = new UpdateRegionDescriptionRequestDto()
        {
            RegionId = 0, // Assuming this ID exists in the database
            RegionDescription = "Updated Region Description"
        };

        // Act
        var result = await _service.UpdateRegionDescription(region);

        // Assert
        Assert.Equal(ActionResultStringEnum.Success.ToString(), result);
    }

    [Fact]
    public async Task DeleteRegion()
    {
        // Arrange
        var regionId = 0; // Assuming this ID exists in the database

        // Act
        var result = await _service.DeleteRegion(regionId);

        // Assert
        Assert.Equal(ActionResultStringEnum.Success.ToString(), result);
    }
}

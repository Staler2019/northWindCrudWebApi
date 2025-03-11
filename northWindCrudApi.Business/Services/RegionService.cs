using northWindCrudApi.Business.DTOs;
using northWindCrudApi.Business.IServices;
using northWindCrudApi.Data.IRespositories;

namespace northWindCrudApi.Business.Services;

public class RegionService(IRegionRepository repo) : IRegionService
{
    public async Task<IEnumerable<RegionDto>> GetRegions()
    {
        var regions = await repo.GetRegionsAsync();

        var regionDtos = regions.Select(r => new RegionDto
        {
            RegionId = r.RegionId,
            RegionDescription = r.RegionDescription
        });

        return regionDtos;
    }
}

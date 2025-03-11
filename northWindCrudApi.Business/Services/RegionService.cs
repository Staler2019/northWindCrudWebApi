using northWindCrudApi.Business.DTOs;
using northWindCrudApi.Business.Enums;
using northWindCrudApi.Business.IServices;
using northWindCrudApi.Data.IRespositories;
using northWindCrudApi.Data.Models;

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

    public async Task<string> DeleteRegion(int id)
    {
        var region = await repo.GetRegionByIdAsync(id);

        if (region == null)
        {
            return ActionResultStringEnum.NotFound.ToString();
        }

        var result = await repo.DeleteRegionAsync(region);

        if (result)
        {
            return ActionResultStringEnum.Success.ToString();
        }

        return ActionResultStringEnum.CannotDelete.ToString();
    }

    public async Task<string> UpdateRegionDescription(UpdateRegionDescriptionRequestDto request)
    {
        var region = await repo.GetRegionByIdAsync(request.RegionId);

        if (region == null)
        {
            return ActionResultStringEnum.NotFound.ToString();
        }

        region.RegionDescription = request.RegionDescription;

        var result = await repo.EditRegionAsync(region);

        if (result)
        {
            return ActionResultStringEnum.Success.ToString();
        }
        else
        {
            return ActionResultStringEnum.CannotUpdate.ToString();
        }
    }

    public async Task<RegionDto?> CreateRegion(CreateRegionRequestDto request)
    {
        var region = new Region
        {
            RegionId          = request.RegionId,
            RegionDescription = request.RegionDescription
        };

        var result = await repo.AddRegionAsync(region);

        if (result == null)
        {
            return null;
        }

        return new RegionDto
        {
            RegionId          = result.RegionId,
            RegionDescription = result.RegionDescription
        };

    }
}

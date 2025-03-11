using northWindCrudApi.Business.DTOs;

namespace northWindCrudApi.Business.IServices;

public interface IRegionService
{
    public Task<IEnumerable<RegionDto>> GetRegions();
    public Task<string> DeleteRegion(int id);
    public Task<string> UpdateRegionDescription(UpdateRegionDescriptionRequestDto request);
    public Task<RegionDto?> CreateRegion(CreateRegionRequestDto request);
}

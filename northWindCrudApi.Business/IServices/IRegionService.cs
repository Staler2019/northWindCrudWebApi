using northWindCrudApi.Business.DTOs;

namespace northWindCrudApi.Business.IServices;

public interface IRegionService
{
    public Task<IEnumerable<RegionDto>> GetRegions();
}

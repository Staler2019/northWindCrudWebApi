using northWindCrudApi.Data.IRespositories.Base;
using northWindCrudApi.Data.Models;

namespace northWindCrudApi.Data.IRespositories;

public interface IRegionRepository : IBaseRepository<Region>
{
    public Task<IEnumerable<Region>> GetRegionsAsync();
    public Task<bool>                EditRegionAsync(Region   region);
    public Task<Region?>             AddRegionAsync(Region    region);
    public Task<bool>                DeleteRegionAsync(Region region);
    public Task<Region?>             GetRegionByIdAsync(int   id, bool asNoTracking = false);
}

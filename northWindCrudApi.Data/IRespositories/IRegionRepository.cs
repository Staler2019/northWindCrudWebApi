using northWindCrudApi.Data.IRespositories.Base;
using northWindCrudApi.Data.Models;

namespace northWindCrudApi.Data.IRespositories;

public interface IRegionRepository : IBaseRepository<Region>
{
    public Task<IEnumerable<Region>> GetRegionsAsync();
}

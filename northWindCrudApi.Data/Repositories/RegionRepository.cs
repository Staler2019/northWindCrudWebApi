using Microsoft.EntityFrameworkCore;
using northWindCrudApi.Data.Data;
using northWindCrudApi.Data.IRespositories;
using northWindCrudApi.Data.Models;
using northWindCrudApi.Data.Repositories.Base;

namespace northWindCrudApi.Data.Repositories;

public class RegionRepository(ApplicationDbContext db) : BaseRepository<Region>(db), IRegionRepository
{
    public async Task<IEnumerable<Region>> GetRegionsAsync()
    {
        return await db.Regions.AsNoTracking().ToListAsync();
    }
}

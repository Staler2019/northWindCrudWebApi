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

    public async Task<bool> EditRegionAsync(Region region)
    {
        try
        {
            db.Regions.Update(region);
            await db.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Region?> AddRegionAsync(Region region)
    {
        try {
            if (await GetRegionByIdAsync(region.RegionId) != null)
            {
                return null;
            }

            await db.Regions.AddAsync(region);
            await db.SaveChangesAsync();

            return region;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> DeleteRegionAsync(Region region)
    {
        try
        {
            db.Regions.Remove(region);
            await db.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Region?> GetRegionByIdAsync(int id, bool asNoTracking = false)
    {
        try
        {
            var query = db.Regions.AsQueryable();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(r => r.RegionId == id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

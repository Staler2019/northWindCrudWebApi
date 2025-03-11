using northWindCrudApi.Data.Data;
using northWindCrudApi.Data.IRespositories.Base;

namespace northWindCrudApi.Data.Repositories.Base;

public class BaseRepository<TEntity>(ApplicationDbContext db)
    : IBaseRepository<TEntity> where TEntity : class
{

}

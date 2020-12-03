using CA.ProductCoreApp.DataAccess.Interfaces;
using CA.ProductCoreApp.Entities.Concrete;

namespace CA.ProductCoreApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRoleRepository : EfGenericRepository<AppUserRole>, IAppUserRoleDal 
    {
    }
}

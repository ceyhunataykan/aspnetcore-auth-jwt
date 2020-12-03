using CA.ProductCoreApp.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CA.ProductCoreApp.DataAccess.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}

using CA.ProductCoreApp.Entities.Concrete;
using System.Threading.Tasks;

namespace CA.ProductCoreApp.Business.Interfaces
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> FindByName(string roleName);
    }
}

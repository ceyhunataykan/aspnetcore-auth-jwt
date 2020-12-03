using CA.ProductCoreApp.Entities.Concrete;
using CA.ProductCoreApp.Entities.Dtos.AppUserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CA.ProductCoreApp.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto);
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}

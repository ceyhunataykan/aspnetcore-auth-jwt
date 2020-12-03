using CA.ProductCoreApp.Entities.Concrete;
using System.Collections.Generic;

namespace CA.ProductCoreApp.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(AppUser appUser, List<AppRole> roles);
    }
}

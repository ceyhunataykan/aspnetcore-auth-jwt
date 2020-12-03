using CA.ProductCoreApp.Business.Interfaces;
using CA.ProductCoreApp.DataAccess.Interfaces;
using CA.ProductCoreApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.ProductCoreApp.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {
        }
    }
}

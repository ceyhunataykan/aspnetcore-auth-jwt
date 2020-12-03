using CA.ProductCoreApp.Business.Interfaces;
using CA.ProductCoreApp.Business.StringInfos;
using CA.ProductCoreApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.ProductCoreApp.WebApi
{
    public class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, 
            IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);

            if (adminRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);

            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserName("ceyhunataykan");

            if (adminUser == null)
            {
                await appUserService.Add(new AppUser
                {
                    Username = "ceyhunataykan",
                    Password = "123",
                    FullName = "Ceyhun Ataykan"
                });
            }

            var role = await appRoleService.FindByName(RoleInfo.Admin);
            var user = await appUserService.FindByUserName("ceyhunataykan");

            await appUserRoleService.Add(new AppUserRole
            {
                AppUserId = user.Id,
                AppRoleId = role.Id
            });
        } 
    }
}

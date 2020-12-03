using CA.ProductCoreApp.DataAccess.Concrete.EntityFrameworkCore.Context;
using CA.ProductCoreApp.DataAccess.Interfaces;
using CA.ProductCoreApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.ProductCoreApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            using var context = new ProductContext();

             return  await context.AppUsers.Join(context.AppUserRoles, u => u.Id, r => r.AppUserId,
                (user, userRole) => new
                {
                    user = user,
                    userRole = userRole
                }).Join(context.AppRoles, ur => ur.userRole.AppRoleId, r => r.Id,
                (joinTable, role) => new
                {
                    user = joinTable.user,
                    userRole = joinTable.userRole,
                    role = role
                }).Where(I => I.user.Username == userName).Select(I => new AppRole 
                { 
                    Id = I.role.Id,
                    Name = I.role.Name
                }).ToListAsync();
        }
    }
}

using CA.ProductCoreApp.Entities.Interfaces;
using System.Collections.Generic;

namespace CA.ProductCoreApp.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}

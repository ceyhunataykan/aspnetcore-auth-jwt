using System.Collections.Generic;

namespace CA.ProductCoreApp.Entities.Dtos.AppUserDtos
{
    public class AppUserDto
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}

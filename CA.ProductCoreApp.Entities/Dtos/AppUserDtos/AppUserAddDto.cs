using CA.ProductCoreApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.ProductCoreApp.Entities.Dtos.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}

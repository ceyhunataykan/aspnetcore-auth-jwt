using CA.ProductCoreApp.Business.Concrete;
using CA.ProductCoreApp.Business.Interfaces;
using CA.ProductCoreApp.Business.ValidationRules.FluentValidation;
using CA.ProductCoreApp.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using CA.ProductCoreApp.DataAccess.Interfaces;
using CA.ProductCoreApp.Entities.Dtos.AppUserDtos;
using CA.ProductCoreApp.Entities.Dtos.ProductDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CA.ProductCoreApp.Business.Containers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();

            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();
        }
    }
}

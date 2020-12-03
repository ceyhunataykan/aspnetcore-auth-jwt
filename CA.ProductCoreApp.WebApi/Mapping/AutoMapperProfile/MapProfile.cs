using AutoMapper;
using CA.ProductCoreApp.Entities.Concrete;
using CA.ProductCoreApp.Entities.Dtos.AppUserDtos;
using CA.ProductCoreApp.Entities.Dtos.ProductDtos;

namespace CA.ProductCoreApp.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();

            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
        }
    }
}

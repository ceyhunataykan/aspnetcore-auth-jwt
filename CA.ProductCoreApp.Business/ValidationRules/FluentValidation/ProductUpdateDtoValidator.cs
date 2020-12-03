using CA.ProductCoreApp.Entities.Concrete;
using CA.ProductCoreApp.Entities.Dtos.ProductDtos;
using FluentValidation;

namespace CA.ProductCoreApp.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez!");
        }
    }
}

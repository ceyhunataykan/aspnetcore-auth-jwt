using CA.ProductCoreApp.Entities.Dtos.AppUserDtos;
using FluentValidation;

namespace CA.ProductCoreApp.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.Username).NotEmpty().WithMessage("Kulanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola Boş Geçilemez");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez");
        }
    }
}

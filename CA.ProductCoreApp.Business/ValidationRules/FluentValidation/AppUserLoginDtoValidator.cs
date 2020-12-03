using CA.ProductCoreApp.Entities.Dtos.AppUserDtos;
using FluentValidation;

namespace CA.ProductCoreApp.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola Boş Geçilemez");
        }
    }
}

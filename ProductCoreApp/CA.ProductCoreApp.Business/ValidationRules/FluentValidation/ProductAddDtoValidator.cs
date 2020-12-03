using CA.ProductCoreApp.Entities.Dtos.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.ProductCoreApp.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez!");
        }
    }
} 

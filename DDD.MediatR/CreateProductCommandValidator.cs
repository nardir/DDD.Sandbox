using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.MediatR
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.ProductName).NotEmpty().WithMessage("Product name not set");
            RuleFor(c => c.ProductGroup).NotNull().WithMessage("Product group not set");
        }
    }
}

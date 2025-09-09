using FluentValidation;
using TCIG.Application.DTOs;

namespace TCIG.Application.Validators
{

    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required and should not exceed 100 characters.")
                .MaximumLength(100).WithMessage("Product name is required and should not exceed 100 characters.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("The price must be between $1 and $10,000.")
                .InclusiveBetween(1, 10000).WithMessage("The price must be between $1 and $10,000.");

            RuleFor(x => x.Stock)
                .NotEmpty().WithMessage("Stock quantity must be at least 0.")
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be at least 0.");
        }
    }
}

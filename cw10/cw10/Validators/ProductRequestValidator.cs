using cw10.RequestModels;
using FluentValidation;

namespace cw10.Validators;

public class ProductRequestValidator : AbstractValidator<ProductRequestModel>
{
    public ProductRequestValidator()
    {
        RuleFor(r => r.ProductName).NotNull().MaximumLength(100);
        RuleFor(r => r.ProductDepth).NotNull();
        RuleFor(r => r.ProductHeight).NotNull();
        RuleFor(r => r.ProductWidth).NotNull();
        RuleFor(r => r.ProductWeight).NotNull();
        RuleFor(r => r.ProductCategories).NotNull();
    }
}
using FluentValidation;
using PMS.Entity.Models;

namespace PMS.Entity.Validation
{
    public class ProductValidator : AbstractValidator<ProductDetailDto>
    {
        public ProductValidator()
        {
            RuleFor(pro => pro.Id)
                .GreaterThanOrEqualTo(0);

            RuleFor(pro => pro.Title)
                .NotEmpty().WithMessage(string.Format(ValidationMessage.required, "Title"))
                .MinimumLength(2).WithMessage(string.Format(ValidationMessage.minLength, "Title", 2))
                .MaximumLength(20).WithMessage(string.Format(ValidationMessage.maxLength, "Title", 20));

            RuleFor(pro => pro.ISBN)
                .NotEmpty().WithMessage(string.Format(ValidationMessage.required, "ISBN"));

            RuleFor(pro => pro.Price)
                .InclusiveBetween(1, 10000).WithMessage(string.Format(ValidationMessage.range, "Price", 1, 10000));

            RuleFor(pro => pro.Author)
                .NotEmpty().WithMessage(string.Format(ValidationMessage.required, "Author"))
                .MaximumLength(20).WithMessage(string.Format(ValidationMessage.maxLength, "Author", 20));

            RuleFor(pro => pro.CategoryId)
                .GreaterThan(0).WithMessage(string.Format(ValidationMessage.required, "Category"));

            RuleFor(pro => pro.CoverTypeId)
                .GreaterThan(0).WithMessage(string.Format(ValidationMessage.required, "CoverType"));
        }
    }
}

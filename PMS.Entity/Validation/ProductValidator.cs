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
              .NotEmpty()
              .Length(2, 100);

            RuleFor(pro => pro.Price)
                .GreaterThan(0)
                .LessThan(10000);

            RuleFor(pro => pro.Price50)
                .GreaterThan(0)
                .LessThan(10000);

            RuleFor(pro => pro.Author)
              .NotEmpty();

            // Conditional validation
            When(pro => pro.Title.Length > 50, () =>
            {
                RuleFor(pro => pro.Author)
                  .NotEmpty()
                  .WithMessage("Author is required for long titles.");
            });
        }
    }
}

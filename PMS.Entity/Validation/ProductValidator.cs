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
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 characters.")
                .MaximumLength(20).WithMessage("Title must be 20 characters or fewer.");

            RuleFor(pro => pro.ISBN)
                .NotEmpty().WithMessage("ISBN is required.");

            RuleFor(pro => pro.Price)
                .InclusiveBetween(1, 10000).WithMessage("Price must be between 1 and 10000.");

            RuleFor(pro => pro.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(20).WithMessage("Author name must be 20 characters or fewer.");

            RuleFor(pro => pro.CategoryId)
                .GreaterThan(0).WithMessage("Category is required.");

            RuleFor(pro => pro.CoverTypeId)
                .GreaterThan(0).WithMessage("Cover Type is required.");
        }
    }
}

using BMS.Domain.Constants;
using BMS.Domain.Models;
using FluentValidation;

namespace BMS.API.AbstractValidators
{
    public class BookCategoryModelValidator : AbstractValidator<BookCategory>
    {
        public BookCategoryModelValidator()
        {
            RuleFor(rule => rule.CategoryName).NotEmpty().WithMessage(ParameterValidation.InvalidBookCategoryName);
        }
    }
}

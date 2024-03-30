using BMS.Domain.Constants;
using BMS.Domain.Models;
using FluentValidation;

namespace BMS.API.AbstractValidators
{
    public class BookCategoryValidator : AbstractValidator<BookCategory>
    {
        public BookCategoryValidator() {
            RuleFor(r=>r.CategoryName).NotEmpty().WithMessage(ParameterValidation.InvalidBookCategoryName);
        }


    }
}

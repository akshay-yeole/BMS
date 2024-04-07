using BMS.Domain.Constants;
using BMS.Domain.Dto;
using FluentValidation;

namespace BMS.API.AbstractValidators
{
    public class BookCategoryDtoValidator : AbstractValidator<BookCategoryDto>
    {
        public BookCategoryDtoValidator() {
            RuleFor(r=>r.CategoryName)
                .NotEmpty()
                .WithMessage(ParameterValidation.InvalidBookCategoryName)
                .MaximumLength(50)
                .WithMessage("Category name cannot exceed 50 characters.");
        }


    }
}

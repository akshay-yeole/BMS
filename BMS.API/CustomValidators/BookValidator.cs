using BMS.Domain.Constants;
using BMS.Domain.Dto;
using FluentValidation;

namespace BMS.API.CustomValidators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(r => r.CopiesAvailable)
                .GreaterThanOrEqualTo(3)
                .WithMessage(ParameterValidation.InvalidCopiesAvailable);

            RuleFor(r => r.BookName)
                .NotEmpty()
                .WithMessage(ParameterValidation.InvalidBookName);

            RuleFor(r => r.Author)
                .NotEmpty()
                .WithMessage(ParameterValidation.InvalidAuthorName);
            
            RuleFor(r => r.Categoryid)
                .NotEmpty()
                .WithMessage(ParameterValidation.InvalidCategoryId);
        }
    }
}

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
                .WithMessage("Available copies for the book should be at least 3.");

            RuleFor(r => r.BookName)
                .NotEmpty()
                .WithMessage("Book name cannot be empty.");

            RuleFor(r => r.Author)
                .NotEmpty()
                .WithMessage("Author name cannot be empty.");
            
            RuleFor(r => r.Categoryid)
                .NotEmpty()
                .WithMessage("Category ID cannot be empty.");
        }
    }
}

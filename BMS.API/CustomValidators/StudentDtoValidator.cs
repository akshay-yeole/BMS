using BMS.Domain.Dto;
using FluentValidation;

namespace BMS.API.CustomValidators
{
    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {

            RuleFor(model => model.Std)
                .GreaterThan(3)
                .WithMessage("Standard for student should be between 1-10");

            RuleFor(model => model.Div)
                .NotEmpty().WithMessage("Division should not be empty.")
                .Must(div => div == 'a' || div == 'b' || div == 'c')
                .WithMessage("Division should be 'A', 'B', or 'C'.");

            RuleFor(model => model.RollNo)
                .GreaterThan(0).WithMessage("Roll number should be greater than 0.")
                .InclusiveBetween(1, 50).WithMessage("Roll number should be between 1 and 50.");
        }
    }
}

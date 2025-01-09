using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(u => u.Email.Value)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(u => u.CPF.Value)
                .Matches(@"^\d{11}$").WithMessage("CPF must contain exactly 11 digits.");

            RuleFor(u => u.PasswordHash.Hash)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(u => u.PhoneNumber.Number)
                .Matches(@"^\d{10,11}$").WithMessage("Phone number must contain 10 or 11 digits.");
        }
    }
}

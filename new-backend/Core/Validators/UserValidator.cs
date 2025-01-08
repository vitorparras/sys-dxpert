using Core.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must be at most 100 characters long.");

            RuleFor(user => user.Email)
                .NotNull().WithMessage("Email is required.")
                .Must(email => email.IsValid()).WithMessage("Invalid email format.");

            RuleFor(user => user.PasswordHash)
                .NotNull().WithMessage("Password hash is required.");

            RuleFor(user => user.Role)
                .IsInEnum().WithMessage("Invalid role specified.");
        }
    }
}

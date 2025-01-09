using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class ConfigurationValidator : AbstractValidator<Configuration>
    {
        public ConfigurationValidator()
        {
            RuleFor(c => c.Key)
                .NotEmpty().WithMessage("Key is required.")
                .MaximumLength(100).WithMessage("Key must be at most 100 characters.");

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("Value is required.")
                .MaximumLength(500).WithMessage("Value must be at most 500 characters.");

            RuleFor(c => c.CreatedAt)
                .NotEmpty().WithMessage("Created date is required.");
        }
    }
}

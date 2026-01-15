using FluentValidation;
using TrainStation.ValueObjects.Validators;

namespace TrainSation.WebHost.Validators.Base
{
    public class FirstNamePresentationValidator : AbstractValidator<string>
    {
        public FirstNamePresentationValidator() 
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .MinimumLength(FirstNameValidator.MIN_LENGTH)
                .MaximumLength(FirstNameValidator.MAX_LENGTH);
        }
    }
}

using FluentValidation;
using TrainStation.ValueObjects.Validators;

namespace TrainSation.WebHost.Validators.Base
{
    public class LastNamePresentationValidator : AbstractValidator<string>
    {
        public LastNamePresentationValidator() 
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .MinimumLength(LastNameValidator.MIN_LENGTH)
                .MaximumLength(LastNameValidator.MAX_LENGTH);
        }
    }
}

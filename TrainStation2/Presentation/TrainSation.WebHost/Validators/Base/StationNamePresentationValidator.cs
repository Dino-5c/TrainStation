using FluentValidation;
using TrainStation.ValueObjects.Validators;

namespace TrainSation.WebHost.Validators.Base
{
    public class StationNamePresentationValidator : AbstractValidator<string>
    {
        public StationNamePresentationValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .MinimumLength(StationNameValidator.MIN_LENGTH)
                .MaximumLength(StationNameValidator.MAX_LENGTH);
        }
    }
}

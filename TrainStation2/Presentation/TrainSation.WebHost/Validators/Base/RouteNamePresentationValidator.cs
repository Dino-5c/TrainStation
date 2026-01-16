using FluentValidation;
using TrainStation.ValueObjects.Validators;

namespace TrainSation.WebHost.Validators.Base
{
    public class RouteNamePresentationValidator : AbstractValidator<string>
    {
        public RouteNamePresentationValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .MinimumLength(RoNameValidator.MIN_LENGTH)
                .MaximumLength(RoNameValidator.MAX_LENGTH);
        }
    }
}

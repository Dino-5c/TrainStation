using FluentValidation;

namespace TrainSation.WebHost.Validators.Base
{
    public class DistancePresentationValidator : AbstractValidator<int>
    {
        public DistancePresentationValidator()
        {
            RuleFor(x => x)
                .GreaterThan(0);
        }
    }
}

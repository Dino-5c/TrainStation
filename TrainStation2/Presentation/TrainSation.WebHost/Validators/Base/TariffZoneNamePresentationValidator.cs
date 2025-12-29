using FluentValidation;

namespace TrainSation.WebHost.Validators.Base
{
    public class TariffZoneNamePresentationValidator : AbstractValidator<int>
    {
        public TariffZoneNamePresentationValidator()
        {
            RuleFor(x => x)
                .GreaterThanOrEqualTo(0);
        }
    }
}

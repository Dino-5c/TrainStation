using FluentValidation;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.TariffZone
{
    public class CreateTariffZoneValidator : AbstractValidator<CreateTariffZoneRequest>
    {
        public CreateTariffZoneValidator()
        {
            RuleFor(tariffZone => tariffZone.administratorId)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(tariffZone => tariffZone.price)
                .SetValidator(new MoneyAmountPresentationValidator());

            RuleFor(tariffZone => tariffZone.distance)
                .SetValidator(new DistancePresentationValidator());

            RuleFor(tariffZone => tariffZone.tariffZoneName)
                .SetValidator(new TariffZoneNamePresentationValidator());
        }
    }
}

using FluentValidation;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.TariffZone
{
    public class UpdateTariffZoneValidator : AbstractValidator<UpdateTariffZoneRequest>
    {
        public UpdateTariffZoneValidator()
        {

            RuleFor(tariffZone => tariffZone.Id)
                .SetValidator(new GuidPresentationValidator());

             RuleFor(tariffZone => tariffZone.TariffZoneName)
                .SetValidator(new TariffZoneNamePresentationValidator());          
            
            RuleFor(tariffZone => tariffZone.Price)
                .SetValidator(new MoneyAmountPresentationValidator());

            RuleFor(tariffZone => tariffZone.Distance)
                .SetValidator(new DistancePresentationValidator());

            RuleFor(tariffZone => tariffZone.AdministratorId)
                .SetValidator(new GuidPresentationValidator());


        }
    }
}

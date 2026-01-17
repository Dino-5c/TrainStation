using FluentValidation;
using TrainSation.WebHost.Requests.Station;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Station
{
    public class UpdateStationValidator : AbstractValidator<UpdateStationRequest>
    {
        public UpdateStationValidator()
        {
            RuleFor(station => station.Id)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(station => station.StationName)
                .SetValidator(new StationNamePresentationValidator());

            RuleFor(station => station.RouteId)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(station => station.TariffZoneId)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(station => station.StationStatus).IsInEnum().WithMessage("Данного значение среди перечислений не обнаружено");
                
        }
    }
}

using FluentValidation;
using TrainSation.WebHost.Requests.Station;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Station
{
    public class CreateStationValidator : AbstractValidator<CreateStationRequest>
    {
        public CreateStationValidator()
        {
            RuleFor(station => station.StationName)
                .SetValidator(new StationNamePresentationValidator());

            RuleFor(station => station.RouteId)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(station => station.TariffZoneId)
                .SetValidator(new GuidPresentationValidator());
        }
    }
}

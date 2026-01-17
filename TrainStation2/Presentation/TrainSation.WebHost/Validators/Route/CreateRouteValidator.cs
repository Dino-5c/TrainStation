using FluentValidation;
using TrainSation.WebHost.Requests.Route;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Route
{
    public class CreateRouteValidator : AbstractValidator<CreateRouteRequest>
    {
        public CreateRouteValidator()
        {
            RuleFor(route => route.RouteName)
                .SetValidator(new RouteNamePresentationValidator());

            RuleFor(route => route.AdministratorId)
                .SetValidator(new GuidPresentationValidator());
        }
    }
}

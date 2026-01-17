using FluentValidation;
using TrainSation.WebHost.Requests.Route;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Route
{
    public class UpdateRouteValidator : AbstractValidator<UpdateRouteRequest>
    {
        public UpdateRouteValidator()
        {
            RuleFor(route => route.Id)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(route => route.RouteName)
                .SetValidator(new RouteNamePresentationValidator());

            RuleFor(route => route.AdministratorId)
                .SetValidator(new GuidPresentationValidator());
        }
    }
}

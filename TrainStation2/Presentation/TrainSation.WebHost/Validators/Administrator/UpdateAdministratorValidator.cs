using FluentValidation;
using TrainSation.WebHost.Requests.Administrator;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Administrator
{
    public class UpdateAdministratorValidator : AbstractValidator<UpdateAdministratorRequest>
    {
        public UpdateAdministratorValidator()
        {
            RuleFor(administrator => administrator.Id)
                .SetValidator(new GuidPresentationValidator());
            RuleFor(administrator => administrator.AdministratorLastName)
                .SetValidator(new LastNamePresentationValidator());
            RuleFor(administrator => administrator.AdministratorFirstName)
                .SetValidator(new FirstNamePresentationValidator());
        }
    }
}

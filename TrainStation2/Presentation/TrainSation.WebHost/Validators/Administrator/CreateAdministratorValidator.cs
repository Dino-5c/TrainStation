using FluentValidation;
using TrainSation.WebHost.Requests.Administrator;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Administrator
{
    public class CreateAdministratorValidator : AbstractValidator<CreateAdministratorRequest>
    {
        public CreateAdministratorValidator()
        {
            RuleFor(administrator => administrator.AdministratorLastName)
                .SetValidator(new LastNamePresentationValidator());
            RuleFor(administrator => administrator.AdministratorFirstName)
                .SetValidator(new FirstNamePresentationValidator());
        }
    }
}

using FluentValidation;
using TrainSation.WebHost.Requests.Buyer;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Buyer
{
    public class CreateBuyerValidator : AbstractValidator<CreateBuyerRequest>
    {
        public CreateBuyerValidator()
        {
            RuleFor(buyer => buyer.BuyerLastName)
                .SetValidator(new LastNamePresentationValidator());

            RuleFor(buyer => buyer.BuyerFirstName)
                .SetValidator(new FirstNamePresentationValidator());

            RuleFor(buyer => buyer.AdministratorId)
                .SetValidator(new GuidPresentationValidator());
        }
    }
}

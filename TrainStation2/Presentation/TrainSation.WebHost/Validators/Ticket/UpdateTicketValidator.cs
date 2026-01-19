using FluentValidation;
using TrainSation.WebHost.Requests.Ticket;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Ticket
{
    public class UpdateTicketValidator : AbstractValidator<UpdateTicketRequest>
    {
        public UpdateTicketValidator()
        {

            RuleFor(ticket => ticket.Id)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(ticket => ticket.BuyDate)
                .NotEmpty()
                .NotNull();

            RuleFor(ticket => ticket.StartStationId)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(ticket => ticket.EndStationId)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(ticket => ticket.BuyerId)
                .SetValidator(new GuidPresentationValidator());

            RuleFor(ticket => ticket.TicketType)
                .IsInEnum()
                .WithMessage("Данного значения нет у перечислений");

            RuleFor(ticket => ticket.Price)
                .SetValidator(new MoneyAmountPresentationValidator());

            RuleFor(ticket => ticket.PriceProcent)
                .SetValidator(new MoneyAmountPresentationValidator());
        }
    }
}

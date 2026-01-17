using FluentValidation;
using TrainSation.WebHost.Requests.Ticket;
using TrainSation.WebHost.Validators.Base;

namespace TrainSation.WebHost.Validators.Ticket
{
    public class CreateTicketValidator : AbstractValidator<CreateTicketRequest>
    {
        public CreateTicketValidator()
        {
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


        }
    }
}

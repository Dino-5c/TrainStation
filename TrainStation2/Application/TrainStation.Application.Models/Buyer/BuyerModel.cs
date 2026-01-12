using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;
using TrainStation.Application.Models.Ticket;

namespace TrainStation.Application.Models.Buyer
{
    public sealed record class BuyerModel : IModel<Guid>
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid AdministratorId { get; set; }
        public IEnumerable<TicketModel> Tickets { get; init; }
    }
}

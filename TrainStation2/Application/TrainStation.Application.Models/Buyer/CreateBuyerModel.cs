using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Buyer
{
    public record class CreateBuyerModel /* (
        string LastName,
        string FirstName,
        Guid AdministratorId) */ : ICreateModel
    {
        public string BuyerLastName { get; init; }
        public string BuyerFirstName { get; init; }
        public Guid AdministratorId { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Buyer
{
    public record class CreateBuyerModel(
        string LastName,
        string FirstName,
        Guid AdminisratorId) : ICreateModel
    {
    }
}

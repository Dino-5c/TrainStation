using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Base;

namespace TrainStation.Application.Models.Administrator
{
    public record class CreateAdministratorModel(string AdministratorLastName, string AdministratorFirstName) : ICreateModel
    {
    }
}

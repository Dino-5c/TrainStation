using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainStation.Application.Services.Abstractions
{
    public interface IAdministratorApplicationService : IApplicationService<AdministratorModel, CreateAdministratorModel, Guid>
    {
    }
}

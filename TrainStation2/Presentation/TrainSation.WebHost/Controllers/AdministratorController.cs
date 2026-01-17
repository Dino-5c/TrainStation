using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainSation.WebHost.Requests.Administrator;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Responces.Administrator;
using TrainSation.WebHost.Responces.TariffZone;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Services;
using TrainStation.Application.Services.Abstractions;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainSation.WebHost.Controllers
{
    [ApiController]
    [Route("api/Administrator/[controller]")]
    public class AdministratorController(IApplicationService<AdministratorModel, CreateAdministratorModel, Guid> administratorApplicationService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AdministratorShortResponce>))]
        public async Task<IActionResult> GetAllAdministrators(CancellationToken cancellationToken)
        {
            var administrator = await administratorApplicationService.GetModelsAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<AdministratorShortResponce>>(administrator));
        }

        // ShortResponce - для получения краткой информации об сущност.(пример - при возврате списка объектов), DetailedResponce - для получения полной информации об объекте (пример - при выводе информации от idНомеру)?
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdministratorDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetAdministratorById(Guid id, CancellationToken cancellationToken)
        {
            var administrator = await administratorApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (administrator is null)
                return NotFound($"Administrator with id:{id} not found");
            return Ok(mapper.Map<AdministratorDetailedResponce>(administrator));
        }

        [HttpPost] // Запись в Базу Данных 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AdministratorShortResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateAdministrator(CreateAdministratorRequest request, CancellationToken cancellationToken)
        {
            var administrator = mapper.Map<CreateAdministratorModel>(request);
            var createdAdministrator = await administratorApplicationService.CreateModelAsync(administrator, cancellationToken);
            if (createdAdministrator is null)
                return BadRequest($"Administrator can not be created");
            var administratorResponce = mapper.Map<AdministratorShortResponce>(createdAdministrator);
            return CreatedAtAction(nameof(GetAdministratorById), new { administratorResponce.Id }, administratorResponce);
        }

        [HttpPatch]// Редактирование
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdministratorDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateAdministrator(UpdateAdministratorRequest request, CancellationToken cancellationToken)
        {
            var administrator = await administratorApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            if (administrator is null)
                return NotFound($"Administrator with id:{request.Id} not found");

            var newAdministrator = mapper.Map<AdministratorModel>(request);
            
            var isAdministratorUpdated = await administratorApplicationService.UpdateModelAsync(newAdministrator, cancellationToken);
            if (isAdministratorUpdated == false)
                return BadRequest($"Administrator can not be redact");
            // var administratorResponce = mapper.Map<AdministratorDetailedResponce>(administrator);
            // return Ok(administratorResponce) /* CreatedAtAction(nameof(GetAdministratorById), new { administratorResponce.Id }, ) */;
            var updated = await administratorApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            return Ok(mapper.Map<AdministratorDetailedResponce>(updated));
        }

        [HttpDelete] // Удалить экземпляр администратора
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdministratorDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteAdministrator(Guid id, CancellationToken cancellationToken)
        {
            var administrator = await administratorApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (administrator is null)
                return NotFound($"Administrator with id:{id} not found");

            var isAdministratorDel = await administratorApplicationService.DeleteModelAsync(id, cancellationToken);
            if (isAdministratorDel == false)
                return BadRequest($"Administrator can not be delete");
            return Ok(mapper.Map<AdministratorDetailedResponce>(administrator));
        }

        // [HttpPost]
         // public async Task<IActionResult> 
    }
}

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
    [Route("api/TariffZon/[controller]")]
    public class TariffZonesController(IApplicationService<TariffZoneModel, CreateTariffZoneModel, Guid> tariffZoneApplicationService, IMapper mapper) : ControllerBase
    {
        // ShortResponce - для получения краткой информации об сущност.(пример - при возврате списка объектов), DetailedResponce - для получения полной информации об объекте (пример - при выводе информации от idНомеру)?
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TariffZoneDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetTariffZoneById(Guid id, CancellationToken cancellationToken)
        {
            var tariffZone = await tariffZoneApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (tariffZone is null)
                return NotFound($"Tariff Zone with id:{id} not found");
            return Ok(mapper.Map<TariffZoneDetailedResponce>(tariffZone));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TariffZoneShortResponce>))]
        public async Task<IActionResult> GetAllTariffZones(CancellationToken cancellationToken)
        {
            var tariffZones = await tariffZoneApplicationService.GetModelsAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<TariffZoneShortResponce>>(tariffZones));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TariffZoneShortResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateTariffZone(CreateTariffZoneRequest request, CancellationToken cancellationToken)
        {
            var tariffZone = mapper.Map<CreateTariffZoneModel>(request);
            var createdTariffZone = await tariffZoneApplicationService.CreateModelAsync(tariffZone, cancellationToken);
            if (createdTariffZone is null)
                return BadRequest($"Tariff Zone can not be created");
            var tariffZoneResponce = mapper.Map<TariffZoneShortResponce>(createdTariffZone);
            return CreatedAtAction(nameof(GetTariffZoneById), new { tariffZoneResponce.id }, tariffZoneResponce);
        }

        [HttpPatch]// Редактирование
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TariffZoneDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateTariffZone(UpdateTariffZoneRequest request, CancellationToken cancellationToken)
        {
            var tariffZone = await tariffZoneApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            if (tariffZone is null)
                return NotFound($"Tariff Zone with id:{request.Id} not found");


            var isTariffZoneUpdated = await tariffZoneApplicationService.UpdateModelAsync(tariffZone, cancellationToken);
            if (isTariffZoneUpdated == false)
                return BadRequest($"Tariff Zone can not be redact");
            var tariffZoneResponce = mapper.Map<TariffZoneDetailedResponce>(tariffZone);
            return Ok(tariffZoneResponce) /* CreatedAtAction(nameof(GetAdministratorById), new { administratorResponce.Id }, ) */;
        }

        [HttpDelete] // Удалить экземпляр тарифной зоны
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TariffZoneDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteTariffZone(Guid id, CancellationToken cancellationToken)
        {
            var tariffZone = await tariffZoneApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (tariffZone is null)
                return NotFound($"Tariff Zone with id:{id} not found");

            var isTariffZoneDel = await tariffZoneApplicationService.DeleteModelAsync(id, cancellationToken);
            if (isTariffZoneDel == false)
                return BadRequest($"Tariff Zone can not be delete");
            return Ok(mapper.Map<TariffZoneDetailedResponce>(tariffZone));
        }
    }
}

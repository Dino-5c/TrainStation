using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainSation.WebHost.Requests.Route;
using TrainSation.WebHost.Requests.Station;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Responces.Administrator;
using TrainSation.WebHost.Responces.Buyer;
using TrainSation.WebHost.Responces.Route;
using TrainSation.WebHost.Responces.Station;
using TrainSation.WebHost.Responces.TariffZone;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.Station;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Services;
using TrainStation.Application.Services.Abstractions;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainSation.WebHost.Controllers
{
    [ApiController]
    [Route("api/Station/[controller]")]
    public class StationController(IApplicationService<StationModel, CreateStationModel, Guid> stationApplicationService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StationShortResponce>))]
        public async Task<IActionResult> GetAllStantions(CancellationToken cancellationToken)
        {
            var station = await stationApplicationService.GetModelsAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<StationShortResponce>>(station));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StationDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetStationById(Guid id, CancellationToken cancellationToken)
        {
            var station = await stationApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (station is null)
                return NotFound($"Station with id:{id} not found");
            return Ok(mapper.Map<StationDetailedResponce>(station));
        }

        [HttpPost("Create")] // Запись в Базу Данных 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StationShortResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateStation(CreateStationRequest request, CancellationToken cancellationToken)
        {
            var station = mapper.Map<CreateStationModel>(request);
            var createdStation = await stationApplicationService.CreateModelAsync(station, cancellationToken);
            if (createdStation is null)
                return BadRequest($"Station can not be created");
            var stationResponce = mapper.Map<StationShortResponce>(createdStation);
            return CreatedAtAction(nameof(GetStationById), new { stationResponce.Id }, stationResponce);
        }

        [HttpPatch("Redact")]// Редактирование
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StationDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateStation(UpdateStationRequest request, CancellationToken cancellationToken)
        {
            var station = await stationApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            if (station is null)
                return NotFound($"Station with id:{request.Id} not found");

            var newStation = mapper.Map<StationModel>(request); // Новый объект тарифной зоны, требующийся для обновления

            var isStationUpdated = await stationApplicationService.UpdateModelAsync(newStation, cancellationToken);
            if (isStationUpdated == false)
                return BadRequest($"Station can not be redact");
            var stationResponce = await stationApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            return Ok(mapper.Map<StationDetailedResponce>(station)) /* CreatedAtAction(nameof(GetStationById), new { stationResponce.Id }, stationResponce) */;
        }

        [HttpDelete("Delete")] // Удаление
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StationDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteStation(Guid id, CancellationToken cancellationToken)
        {
            var station = await stationApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (station is null)
                return NotFound($"Station with id:{id} not found");

            var isStationDel = await stationApplicationService.DeleteModelAsync(id, cancellationToken);
            if (isStationDel == false)
                return BadRequest($"Station can not be deleted");
            return Ok(mapper.Map<StationDetailedResponce>(station));
        }
    }
}

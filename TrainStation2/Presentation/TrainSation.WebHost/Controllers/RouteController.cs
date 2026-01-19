using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainSation.WebHost.Requests.Administrator;
using TrainSation.WebHost.Requests.Route;
using TrainSation.WebHost.Requests.TariffZone;
using TrainSation.WebHost.Responces.Administrator;
using TrainSation.WebHost.Responces.Route;
using TrainSation.WebHost.Responces.TariffZone;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.TariffZone;
using TrainStation.Application.Services;
using TrainStation.Application.Services.Abstractions;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainSation.WebHost.Controllers
{
    [ApiController]
    [Route("api/Route/[controller]")]
    public class RouteController(IApplicationService<RouteModel, CreateRouteModel, Guid> routeApplicationService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RouteShortResponce>))]
        public async Task<IActionResult> GetAllRoutes(CancellationToken cancellationToken)
        {
            var route = await routeApplicationService.GetModelsAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<RouteShortResponce>>(route));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RouteDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetRouteById(Guid id, CancellationToken cancellationToken)
        {
            var route = await routeApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (route is null)
                return NotFound($"Route with id:{id} not found");
            return Ok(mapper.Map<RouteDetailedResponce>(route));
        }

        [HttpPost("Create")] // Запись в Базу Данных 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RouteShortResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateRoute(CreateRouteRequest request, CancellationToken cancellationToken)
        {
            var route = mapper.Map<CreateRouteModel>(request);
            var createdRoute = await routeApplicationService.CreateModelAsync(route, cancellationToken);
            if (createdRoute is null)
                return BadRequest($"Route can not be created");
            var routeResponce = mapper.Map<RouteShortResponce>(createdRoute);
            return CreatedAtAction(nameof(GetRouteById), new { routeResponce.Id }, routeResponce);
        }

        [HttpPatch("Redact")]// Редактирование
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RouteDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateRoute(UpdateRouteRequest request, CancellationToken cancellationToken)
        {
            var route = await routeApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            if (route is null)
                return NotFound($"Route with id:{request.Id} not found");

            var newRoute = mapper.Map<RouteModel>(request); // Новый объект маршрута, нужный (требующийся) для обновления

            var isRouteUpdated = await routeApplicationService.UpdateModelAsync(newRoute, cancellationToken);
            if (isRouteUpdated == false)
                return BadRequest($"Route can not be redact");
            var routeResponce = await routeApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            return Ok(mapper.Map<RouteDetailedResponce>(route)) /* CreatedAtAction(nameof(GetRouteById), new { routeResponce.Id }, routeResponce) */;
        }

        [HttpDelete("Delete")] // Удаление
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RouteDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteRoute(Guid id, CancellationToken cancellationToken)
        {
            var route = await routeApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (route is null)
                return NotFound($"Route with id:{id} not found");

            var isRouteDel = await routeApplicationService.DeleteModelAsync(id, cancellationToken);
            if (isRouteDel == false)
                return BadRequest($"Route can not be delete");
            return Ok(mapper.Map<RouteDetailedResponce>(route));
        }
    }
}

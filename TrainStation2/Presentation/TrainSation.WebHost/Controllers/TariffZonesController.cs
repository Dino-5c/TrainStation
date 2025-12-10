using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainSation.WebHost.Responces.TariffZone;
using TrainStation.Application.Services.Abstractions.Base;


namespace TrainSation.WebHost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TariffZonesController(IApplicationService tariffZoneApplicationService,  IMapper mapper) : ControllerBase
    {
        // shortResponce, DetailedResponce?
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TariffZoneDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ITariffZoneResult> GetTariffZoneById(Guid id, CancellationToken cancellationToken)
        {
            var tariffZone = await tariffZoneApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (tariffZone is null)
                return NotFound($"Tariff Zone with id:{id} not found");
            return Ok(mapper.Map<TariffZoneDetailedResponce>(tariffZone));
        }
    }
}

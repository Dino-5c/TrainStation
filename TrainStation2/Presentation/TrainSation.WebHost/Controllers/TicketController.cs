using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainSation.WebHost.Requests.Route;
using TrainSation.WebHost.Requests.Station;
using TrainSation.WebHost.Requests.Ticket;
using TrainSation.WebHost.Responces.Buyer;
using TrainSation.WebHost.Responces.Route;
using TrainSation.WebHost.Responces.Station;
using TrainSation.WebHost.Responces.Ticket;
using TrainStation.Application.Models.Route;
using TrainStation.Application.Models.Station;
using TrainStation.Application.Models.Ticket;
using TrainStation.Application.Services;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainSation.WebHost.Controllers
{
    [ApiController]
    [Route("api/Ticket/[controller]")]
    public class TicketController(IApplicationService<TicketModel, CreateTicketModel, Guid> ticketApplicationService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TicketShortResponce>))]
        public async Task<IActionResult> GetAllTickets(CancellationToken cancellationToken)
        {
            var ticket = await ticketApplicationService.GetModelsAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<TicketShortResponce>>(ticket));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TicketDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetTicketById(Guid id, CancellationToken cancellationToken)
        {
            var ticket = await ticketApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (ticket is null)
                return NotFound($"Ticket with id:{id} not found");
            return Ok(mapper.Map<TicketDetailedResponce>(ticket));
        }

        [HttpPost("Create")] // Запись в Базу Данных 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TicketShortResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateTicket(CreateTicketRequest request, CancellationToken cancellationToken)
        {
            var ticket = mapper.Map<CreateTicketModel>(request);
            var createdTicket = await ticketApplicationService.CreateModelAsync(ticket, cancellationToken);
            if (createdTicket is null)
                return BadRequest($"Ticket can not be created");
            var ticketResponce = mapper.Map<TicketShortResponce>(createdTicket);
            return CreatedAtAction(nameof(GetTicketById), new { ticketResponce.Id }, ticketResponce);
        }

        [HttpPatch("Redact")]// Редактирование
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TicketDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateTicket(UpdateTicketRequest request, CancellationToken cancellationToken)
        {
            var ticket = await ticketApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            if (ticket is null)
                return NotFound($"Route with id:{request.Id} not found");

            var newTicket = mapper.Map<TicketModel>(request); // Новый объект маршрута, нужный (требующийся) для обновления

            var isTicketUpdated = await ticketApplicationService.UpdateModelAsync(newTicket, cancellationToken);
            if (isTicketUpdated == false)
                return BadRequest($"Ticket can not be redact");
            var ticketResponce = await ticketApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            return Ok(mapper.Map<TicketDetailedResponce>(ticket)) /* CreatedAtAction(nameof(GetRouteById), new { routeResponce.Id }, routeResponce) */;
        }

        [HttpDelete("Delete")] // Удаление
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TicketDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteTicket(Guid id, CancellationToken cancellationToken)
        {
            var ticket = await ticketApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (ticket is null)
                return NotFound($"Ticket with id:{id} not found");

            var isTicketDel = await ticketApplicationService.DeleteModelAsync(id, cancellationToken);
            if (isTicketDel == false)
                return BadRequest($"Ticket can not be deleted");
            return Ok(mapper.Map<TicketDetailedResponce>(ticket));
        }

    }
}

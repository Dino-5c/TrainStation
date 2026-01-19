using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainSation.WebHost.Requests.Administrator;
using TrainSation.WebHost.Requests.Buyer;
using TrainSation.WebHost.Responces.Administrator;
using TrainSation.WebHost.Responces.Buyer;
using TrainStation.Application.Models.Administrator;
using TrainStation.Application.Models.Buyer;
using TrainStation.Application.Services;
using TrainStation.Application.Services.Abstractions;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainSation.WebHost.Controllers
{
    [ApiController]
    [Route("api/Buyer/[controller]")]
    public class BuyerController(IApplicationService<BuyerModel, CreateBuyerModel, Guid> buyerApplicationService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BuyerShortResponce>))]
        public async Task<IActionResult> GetAllBuyers(CancellationToken cancellationToken)
        {
            var buyer = await buyerApplicationService.GetModelsAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<BuyerShortResponce>>(buyer));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetBuyerById(Guid id, CancellationToken cancellationToken)
        {
            var buyer = await buyerApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (buyer is null)
                return NotFound($"Buyer with id:{id} not found");
            return Ok(mapper.Map<BuyerDetailedResponce>(buyer));
        }

        [HttpPost("Create")] // Запись в Базу Данных 
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BuyerShortResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CreateBuyer(CreateBuyerRequest request, CancellationToken cancellationToken)
        {
            var buyer = mapper.Map<CreateBuyerModel>(request);
            var createdBuyer = await buyerApplicationService.CreateModelAsync(buyer, cancellationToken);
            if (createdBuyer is null)
                return BadRequest($"Buyer can not be created");
            var buyerResponce = mapper.Map<BuyerShortResponce>(createdBuyer);
            return CreatedAtAction(nameof(GetBuyerById), new { buyerResponce.Id }, buyerResponce);
        }

        [HttpPatch("Redacting")]// Редактирование
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateBuyer(UpdateBuyerRequest request, CancellationToken cancellationToken)
        {
            var buyer = await buyerApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            if (buyer is null)
                return NotFound($"Buyer with id:{request.Id} not found");

            var newBuyer = mapper.Map<BuyerModel>(request);

            var isBuyerUpdated = await buyerApplicationService.UpdateModelAsync(newBuyer, cancellationToken);
            if (isBuyerUpdated == false)
                return BadRequest($"Buyer can not be redacted");
            // var buyerResponce = mapper.Map<BuyerDetailedResponce>(buyer);
            // return Ok(buyerResponce) /* CreatedAtAction(nameof(GetBuyerById), new { buyerResponce.Id }, ) */;
            var updated = await buyerApplicationService.GetModelByIdAsync(request.Id, cancellationToken);
            return Ok(mapper.Map<BuyerDetailedResponce>(updated));
        }

        [HttpDelete("Delete")] // Удалить экземпляр покупателя
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerDetailedResponce))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteBuyer(Guid id, CancellationToken cancellationToken)
        {
            var buyer = await buyerApplicationService.GetModelByIdAsync(id, cancellationToken);
            if (buyer is null)
                return NotFound($"Buyer with id:{id} not found");

            var isBuyerDel = await buyerApplicationService.DeleteModelAsync(id, cancellationToken);
            if (isBuyerDel == false)
                return BadRequest($"Buyer can not be deleted");
            return Ok(mapper.Map<BuyerDetailedResponce>(buyer));
        }
    }
}

using CardInventoryServiceCore.IService;
using CardInventoryServiceDomain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardInventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpPost("add-card")]
        public IActionResult AddCard([FromBody]StockRequestDto request)
        {
            return Ok(_stockService.AddCard(request));
        }
        [HttpGet("get-available-card")]
        public IActionResult GetAvailableCards()
        {
            return Ok(_stockService.GetAvailableCards());
        }
        [HttpGet("get-card-by-supplier")]
        public IActionResult GetAllCardsBySupplier([FromBody]string supplier)
        {
            return Ok(_stockService.GetAllCardsBySupplier(supplier));
        }
        [HttpGet("get-used-card")]
        public IActionResult GetUsedCards()
        {
            return Ok(_stockService.GetUsedCards());
        }
        [HttpGet("get-car-summary")]
        public IActionResult GetCardSummary()
        {
            return Ok(_stockService.GetCardSummary());
        }
    }
}

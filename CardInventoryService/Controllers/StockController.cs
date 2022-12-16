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
        [HttpPost("add_stock")]
        public async Task<IActionResult> AddStock([FromBody]StockRequestDto request)
        {
            return Ok(await _stockService.AddStock(request));
        }
        [HttpGet("get_card_stock_count")]
        public IActionResult GetCardStockCount()
        {
            return Ok(_stockService.GetCardStockCount());
        }

        [HttpGet("get_card_stock_count_by_supplier")]
        public IActionResult GetCardStockCountBySupplier(string supplier)
        {
            return Ok(_stockService.GetCardStockCountBySupplier(supplier));
        }
        [HttpGet("get_stock_summary")]
        public IActionResult GetStockSummary()
        {
            return Ok(_stockService.GetStockSummary());
        }
    }
}

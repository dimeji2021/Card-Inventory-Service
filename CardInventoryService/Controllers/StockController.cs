using CardInventoryServiceDomain.DTO;
using CardInventoryServiceInfrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CardInventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        [HttpPost("AddStock")]
        public async Task<IActionResult> AddStock([FromBody]StockRequestDto request)
        {
            return Ok(await _stockRepository.AddStock(request));
        }
        [HttpGet("GetCardStockCount")]
        public IActionResult GetCardStockCount()
        {
            return Ok(_stockRepository.GetCardStockCount());
        }

        [HttpGet("GetCardStockCountBySupplier/{supplier}")]
        public IActionResult GetCardStockCountBySupplier(string supplier)
        {
            return Ok(_stockRepository.GetCardStockCountBySupplier(supplier));
        }
        [HttpGet("GetStockSummary")]
        public IActionResult GetStockSummary()
        {
            return Ok(_stockRepository.GetStockSummary());
        }
    }
}

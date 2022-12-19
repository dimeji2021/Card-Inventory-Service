using CardInventoryServiceCore.IService;
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceInfrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardInventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpPost("CreateCard")]
        public async Task<IActionResult> CreateCard([FromBody] CardRequestDto request)
        {
            return Ok(await _cardService.CreateCard(request));
        }
        [HttpGet("GetCardById/{Id}")]
        public IActionResult GetCardById(Guid Id)
        {
            return Ok(_cardService.GetCardById(Id));
        }
        [HttpGet("GetCardByIssuerRef/{Id}")]
        public IActionResult GetCardByIssuerRef(Guid Id)
        {
            return Ok(_cardService.GetCardByIssuerRef(Id));
        }
        [HttpGet("GetPrintedCards/page/{pageSize}/{pageNumber}")]
        public IActionResult GetPrintedCards(int pageSize, int pageNumber)
        {
            return Ok(_cardService.GetPrintedCards(pageSize, pageNumber));
        }
        [HttpGet("GetUsedCardCount")]
        public IActionResult GetUsedCardsCount()
        {
            return Ok(_cardService.GetUsedCardsCount());
        }
    }
}

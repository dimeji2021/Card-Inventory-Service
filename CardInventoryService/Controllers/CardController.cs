using CardInventoryServiceDomain.DTO;
using CardInventoryServiceInfrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CardInventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardRepository _cardRepository;
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        [HttpPost("CreateCard")]
        public async Task<IActionResult> CreateCard([FromBody] CardRequestDto request)
        {
            return Ok(await _cardRepository.CreateCard(request));
        }
        [HttpGet("GetCardById/{Id}")]
        public IActionResult GetCardById(Guid Id)
        {
            return Ok(_cardRepository.GetCardById(Id));
        }
        [HttpGet("GetCardByIssuerRef/{Id}")]
        public IActionResult GetCardByIssuerRef(Guid Id)
        {
            return Ok(_cardRepository.GetCardByIssuerRef(Id));
        }
        [HttpGet("GetPrintedCards/page/{pageSize}/{pageNumber}")]
        public IActionResult GetPrintedCards(int pageSize, int pageNumber)
        {
            return Ok(_cardRepository.GetPrintedCards(pageSize, pageNumber));
        }
        [HttpGet("GetUsedCardCount")]
        public IActionResult GetUsedCardsCount()
        {
            return Ok(_cardRepository.GetUsedCardsCount());
        }
    }
}

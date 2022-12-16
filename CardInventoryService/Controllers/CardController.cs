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
        [HttpPost("create_card")]
        public async Task<IActionResult> CreateCard([FromBody] CardRequestDto request)
        {
            return Ok(await _cardService.CreateCard(request));
        }
        [HttpGet("get_card_by_Id")]
        public IActionResult GetCardById(Guid Id)
        {
            return Ok(_cardService.GetCardById(Id));
        }
        [HttpGet("get_card_by_IssuerRef")]
        public IActionResult GetCardByIssuerRef(Guid Id)
        {
            return Ok(_cardService.GetCardByIssuerRef(Id));
        }
        [HttpGet("get_printed_cards")]
        public IActionResult GetPrintedCards(int pageSize, int pageNumber)
        {
            return Ok(_cardService.GetPrintedCards(pageSize, pageNumber));
        }
        [HttpGet("get_used_card_count")]
        public IActionResult GetUsedCardsCount()
        {
            return Ok(_cardService.GetUsedCardsCount());
        }
    }
}

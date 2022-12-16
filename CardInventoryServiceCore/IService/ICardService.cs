using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceCore.IService
{
    public interface ICardService
    {
        Task<bool> CreateCard(CardRequestDto model);
        Card GetCardById(Guid Id);
        List<Card> GetCardByIssuerRef(Guid Id);
        List<Card> GetPrintedCards(int pageSize, int pageNumber);
        int GetUsedCardsCount();
    }
}
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceInfrastructure.IRepository
{
    public interface ICardRepository
    {
        Task<bool> CreateCard(CardRequestDto model);
        Card GetCardById(Guid Id);
        List<Card> GetCardByIssuerRef(Guid issuerRef);
        List<Card> GetPrintedCards(int pageSize, int pageNumber);
        int GetUsedCardsCount();
    }
}
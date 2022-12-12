using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceInfrastructure.IRepository
{
    public interface IStockRepository
    {
        Task<bool> AddCard(Stock model);
        int GetAvailableCards();
        int GetAllCardsBySupplier(string supplierName);
        StockSummaryDto GetCardSummary();
        int GetUsedCards();
    }
}
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceCore.IService
{
    public interface IStockService
    {
        Task<bool> AddCard(StockRequestDto model);
        int GetAllCardsBySupplier(string supplierName);
        int GetAvailableCards();
        StockSummaryDto GetCardSummary();
        int GetUsedCards();
    }
}
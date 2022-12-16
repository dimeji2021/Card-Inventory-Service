using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceCore.IService
{
    public interface IStockService
    {
        Task<bool> AddStock(StockRequestDto model);
        int GetCardStockCountBySupplier(string supplierName);
        int GetCardStockCount();
        StockSummaryDto GetStockSummary();
    }
}
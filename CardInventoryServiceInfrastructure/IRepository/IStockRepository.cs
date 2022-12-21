using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceInfrastructure.IRepository
{
    public interface IStockRepository
    {
        Task<bool> AddStock(StockRequestDto model);
        int GetCardStockCount();
        int GetCardStockCountBySupplier(string supplierName);
        StockSummaryDto GetStockSummary();
    }
}
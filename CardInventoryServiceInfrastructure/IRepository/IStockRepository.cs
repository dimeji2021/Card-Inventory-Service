using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceInfrastructure.IRepository
{
    public interface IStockRepository
    {
        Task<bool> AddStock(Stock model);
        int GetCardStockCount();
        int GetCardStockCountBySupplier(string supplierName);
        StockSummaryDto GetStockSummary();
    }
}
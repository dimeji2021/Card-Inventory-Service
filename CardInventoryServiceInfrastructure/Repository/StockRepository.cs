using CardInventoryServiceDomain.Core.Utilities;
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;
using CardInventoryServiceInfrastructure.IRepository;

namespace CardInventoryServiceInfrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly InventoryDbContext _context;

        public StockRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddStock(StockRequestDto model)
        {
            var stock = new Stock()
            {
                Id = Guid.NewGuid(),
                SupplierName = model.SupplierName,
                ReceiverName = model.ReceiverName,
                DateSupplied = model.DateSupplied,
                QuantityReceived = model.QuantitySupplied,
                DateReceived = DateTime.Now
            };
            await _context.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock.Id;
        }
        public int GetCardStockCount()
        {
            return _context.Stocks.Sum(c => c.QuantityReceived);
        }
        public int GetCardStockCountBySupplier(string supplierName)
        {
            return _context.Stocks.Where(s => s.SupplierName == supplierName).Sum(c => c.QuantityReceived);
        }
        public StockSummaryDto GetStockSummary()
        {
            int copiesStocked = _context.Stocks.Sum(c => c.QuantityReceived);
            int copiesLeft = copiesStocked - (_context.Cards.Count());

            StockSummaryDto sumR = new StockSummaryDto();
            sumR.CopiesStocked = copiesStocked;
            sumR.CopiesLeft = copiesLeft <= 0 ? 0 : copiesLeft;
            sumR.LastRestock = _context.Stocks.OrderBy(s => s.DateReceived).LastOrDefault().DateReceived;
            return sumR;
        }
    }
}

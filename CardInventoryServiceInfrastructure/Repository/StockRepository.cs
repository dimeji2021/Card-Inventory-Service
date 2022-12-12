using CardInventoryServiceDomain.Model;
using CardInventoryServiceInfrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardInventoryServiceInfrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly InventoryDbContext _context;
        public StockRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCard(Stock model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }
        public int GetAvailableCards()
        {
            return _context.Stocks.Count();
        }
        public int GetAllCardsBySupplier(string supplierName)
        {
            return _context.Stocks.Where(s => s.SupplierName == supplierName).Count();
        }
        public int GetUsedCards()
        {
            return _context.Stocks.Where(s => s.IsUsed == true).Count();
        }
        public StockSummaryDto GetCardSummary()
        {
            StockSummaryDto sumR = new StockSummaryDto();
            sumR.CopiesStocked = _context.Stocks.Count();
            sumR.CopiesLeft = _context.Stocks.Select(s => s.IsUsed == false).Count();
            sumR.LastRestock = _context.Stocks.OrderBy(s => s.DateReceived).LastOrDefault().DateReceived;
            return sumR;
        }
    }
}

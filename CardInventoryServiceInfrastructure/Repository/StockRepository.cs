using AutoMapper;
using CardInventoryServiceDomain.DTO;
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
        private readonly IMapper _mapper;

        public StockRepository(InventoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddStock(StockRequestDto model)
        {
            var stock = _mapper.Map<Stock>(model);
            await _context.AddAsync(stock);
            await _context.SaveChangesAsync();
            return true;
        }
        public int GetCardStockCount()
        {
            return _context.Stocks.Sum(c=>c.QuantityReceived);
        }
        public int GetCardStockCountBySupplier(string supplierName)
        {
            return _context.Stocks.Where(s => s.SupplierName == supplierName).Sum(c=>c.QuantityReceived);
        }
        public StockSummaryDto GetStockSummary()
        {
            int copiesStocked = _context.Stocks.Sum(c => c.QuantityReceived);
            int copiesLeft = copiesStocked - (_context.Cards.Count());

            StockSummaryDto sumR = new StockSummaryDto();
            sumR.CopiesStocked = copiesStocked;
            sumR.CopiesLeft = copiesLeft<=0 ? 0 : copiesLeft;
            sumR.LastRestock = _context.Stocks.OrderBy(s => s.DateReceived).LastOrDefault().DateReceived;
            return sumR;
        }
    }
}

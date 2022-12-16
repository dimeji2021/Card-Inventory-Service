using AutoMapper;
using CardInventoryServiceCore.IService;
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;
using CardInventoryServiceInfrastructure.IRepository;

namespace CardInventoryServiceCore.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddStock(StockRequestDto model)
        {
            var res =_mapper.Map<Stock>(model);
            return await _stockRepository.AddStock(res);
        }
        public int GetCardStockCount()
        {
            return _stockRepository.GetCardStockCount();
        }
        public int GetCardStockCountBySupplier(string supplierName)
        {
            return _stockRepository.GetCardStockCountBySupplier(supplierName);
        }
        public StockSummaryDto GetStockSummary()
        {
            return _stockRepository.GetStockSummary();
        }
    }
}

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
        public Task<bool> AddCard(StockRequestDto model)
        {
            var res =_mapper.Map<Stock>(model);
            return _stockRepository.AddCard(res);
        }
        public int GetAvailableCards()
        {
            return _stockRepository.GetAvailableCards();
        }
        public int GetAllCardsBySupplier(string supplierName)
        {
            return _stockRepository.GetAllCardsBySupplier(supplierName);
        }
        public int GetUsedCards()
        {
            return _stockRepository.GetUsedCards();
        }
        public StockSummaryDto GetCardSummary()
        {
            return _stockRepository.GetCardSummary();
        }
    }
}

using AutoMapper;
using CardInventoryServiceDomain.DTO;
using CardInventoryServiceDomain.Model;

namespace CardInventoryServiceCore.Utilities
{
    public class StockServiceProfile : Profile
    {
        public StockServiceProfile()
        {
            CreateMap<Stock, StockRequestDto>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(guid => Guid.NewGuid()))
                .ForMember(dest => dest.DateReceived, act => act.MapFrom(time => DateTime.Now))
                .ForMember(dest => dest.QuantityReceived, act => act.MapFrom(quan => quan.QuantitySupplied));
                
        }
    }
}

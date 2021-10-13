using AutoMapper;

namespace Revix.Models
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CryptoListing, CoinData>().ReverseMap()
            .ForMember(dto => dto.LastUpdatedPrice, conf => conf.MapFrom(entity => entity.Quote.USD.LastUpdated))
            .ForMember(dto => dto.Price, conf => conf.MapFrom(entity => entity.Quote.USD.Price))
            .ForMember(dto => dto.MarketCap, conf => conf.MapFrom(entity => entity.Quote.USD.MarketCap));
        }

    }
}
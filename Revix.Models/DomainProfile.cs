using AutoMapper;

namespace Revix.Models
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CryptoListing, CryptoListingVM>().ReverseMap();
        }

    }
}
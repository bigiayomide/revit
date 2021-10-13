using AutoMapper;
using Revix.Data.Interfaces;
using Revix.Data.IRepositories;
using Revix.Models;
using Revix.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Revix.Data.Entities;

namespace Revix.Services.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly ICryptoListingRepo _crytoListingRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CryptoService(IMapper mapper, IUnitOfWork unitOfWork, ICoinMarketCapService coinMarketCapService,
        ICryptoListingRepo crytoListingRepo)
        {
            _coinMarketCapService = coinMarketCapService;
            _crytoListingRepo = crytoListingRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CryptoListingVM> GetandSaveCryptoData(CryptoListingSortDataVM cryptoListingSort)
        {
            var data = await _coinMarketCapService.GetCryptoRates(cryptoListingSort);
            if (data.Status.ErrorMessage != null)
                throw new GlobalException(data.Status.ErrorMessage.ToString());
            await SaveCryptoData(data);
            return data;
        }

        public async Task SaveCryptoData(CryptoListingVM cryptoListing)
        {
            foreach (var item in cryptoListing.Data)
            {
                var getlistings = _crytoListingRepo.List(x => x.Id == item.CoinDataId);
                var getlisting = getlistings.FirstOrDefault();
                if (getlisting != null && (item.LastUpdated > getlisting.LastUpdated || item.Quote.USD.LastUpdated > getlisting.LastUpdatedPrice))
                {
                    var entitytoUpdate = _mapper.Map(item, getlisting);
                    _crytoListingRepo.Update(entitytoUpdate);
                    await _unitOfWork.CommitAsync();
                }
                else if (getlisting == null)
                {
                    var entitytoAdd = _mapper.Map<CryptoListing>(item);
                    _crytoListingRepo.Add(entitytoAdd);
                    await _unitOfWork.CommitAsync();
                }
            }
        }
    }
}

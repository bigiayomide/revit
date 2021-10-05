using Revix.Models;
using Revix.Services.Contracts;
using System.Threading.Tasks;

namespace Revix.Services.Services
{
    public class CyptoService : ICryptoService
    {
        private readonly ICoinMarketCapService _coinMarketCapService;
        public CyptoService(ICoinMarketCapService coinMarketCapService)
        {
            _coinMarketCapService = coinMarketCapService;
        }

        public async Task<CryptoListingVM> GetandSaveCryptoData(CryptoListingSortDataVM cryptoListingSort)
        {
            var data = await _coinMarketCapService.GetCryptoRates(cryptoListingSort);

            await SaveCryptoData(data);
            return data;
        }

        public async Task SaveCryptoData(CryptoListingVM cryptoListing)
        {
            //TODO: Check if data exists
            // if exists update 
            // if not exists create

            throw new System.NotImplementedException();
        }
    }
}

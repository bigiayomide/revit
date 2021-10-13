using Refit;
using Revix.Models;
using Revix.Services.Contracts;
using System.Threading.Tasks;

namespace Revix.Services.Services
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        private ICoinMarketCapService _client;
        public async Task<CryptoListingVM> GetCryptoRates([Query] CryptoListingSortDataVM sortdata)
        {
            return await _client.GetCryptoRates(sortdata);
        }


        public async Task<string> GetCryptoRatetest([Query] CryptoListingSortDataVM sortdata)
        {
            return await _client.GetCryptoRatetest(sortdata);
        }
    }
}

using Refit;
using Revix.Models;
using Revix.Services.Contracts;
using System.Threading.Tasks;

namespace Revix.Services.Services
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        public Task<CryptoListingVM> GetCryptoRates([Query] CryptoListingSortDataVM sortdata)
        {
            throw new System.NotImplementedException();
        }
    }
}

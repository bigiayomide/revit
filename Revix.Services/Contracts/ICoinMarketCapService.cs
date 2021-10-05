using Refit;
using Revix.Models;
using System.Threading.Tasks;

namespace Revix.Services.Contracts
{
    public interface ICoinMarketCapService
    {
        [Get("/v1/cryptocurrency/listings/latest")]
        Task<CryptoListingVM> GetCryptoRates([Query] CryptoListingSortDataVM sortdata);
    }
}

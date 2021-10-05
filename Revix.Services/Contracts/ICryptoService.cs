using Revix.Models;
using System.Threading.Tasks;

namespace Revix.Services.Contracts
{
    public interface ICryptoService
    {
        Task<CryptoListingVM> GetandSaveCryptoData(CryptoListingSortDataVM cryptoListingSort);
        public Task SaveCryptoData(CryptoListingVM cryptoListing);
    }
}

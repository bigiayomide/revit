using Revix.Data.IRepositories;
using Revix.Models;

namespace Revix.Data.Repositories
{
    public class CryptoListingRepo : Repository<CryptoListing>, ICryptoListingRepo
    {
        public CryptoListingRepo(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
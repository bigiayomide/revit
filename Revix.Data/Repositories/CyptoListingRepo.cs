using Revix.Data.IRepositories;
using Revix.Data.Entities;

namespace Revix.Data.Repositories
{
    public class CryptoListingRepo : Repository<Revix.Data.Entities.CryptoListing>, ICryptoListingRepo
    {
        public CryptoListingRepo(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
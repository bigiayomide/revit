using System;
using System.ComponentModel.DataAnnotations;
using Revix.Models;

namespace Revix.Data.Entities
{
    public class CryptoListing : AuditEntity<int>
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public long CoinDataId { get; set; }

        public string Slug { get; set; }
        public long NumMarketPairs { get; set; }
        public long TotalSupply { get; set; }
        public DateTime LastUpdated { get; set; }
        public long Price { get; set; }
        public long MarketCap { get; set; }
        public DateTime LastUpdatedPrice { get; set; }

    }
}
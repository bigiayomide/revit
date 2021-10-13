using System;
using System.ComponentModel.DataAnnotations;

namespace Revix.Models
{
    public class CryptoListing
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Slug { get; set; }
        public int NumMarketPairs { get; set; }
        public int TotalSupply { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public long Price { get; set; }
        public long MarketCap { get; set; }
        public DateTimeOffset LastUpdatedPrice { get; set; }

    }
}
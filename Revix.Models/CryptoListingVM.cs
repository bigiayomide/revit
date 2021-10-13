using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Revix.Models
{
    public class Status
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("error_message")]
        public object ErrorMessage { get; set; }

        [JsonPropertyName("elapsed")]
        public int Elapsed { get; set; }

        [JsonPropertyName("credit_count")]
        public int CreditCount { get; set; }

        [JsonPropertyName("notice")]
        public object Notice { get; set; }

        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }
    }

    public class USD
    {
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("market_cap")]
        public double MarketCap { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

    public class Quote
    {
        [JsonPropertyName("USD")]
        public USD USD { get; set; }
    }

    public class CoinData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("num_market_pairs")]
        public int NumMarketPairs { get; set; }

        [JsonPropertyName("total_supply")]
        public int TotalSupply { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("quote")]
        public Quote Quote { get; set; }
    }

    public class CryptoListingVM
    {
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("data")]
        public List<CoinData> Data { get; set; }
    }
}

using Newtonsoft.Json;

namespace Revix.Models
{
    public class CryptoListingSortDataVM
    {
        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "price_min")]
        public long PriceMin { get; set; }

        [JsonProperty(PropertyName = "price_max")]
        public long PriceMax { get; set; }
    }
}

using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Refit;

namespace Revix.Models
{
    public class CryptoListingSortDataVM
    {
        [AliasAs("start")]
        public int Start { get; set; }
        [AliasAs("limit")]
        public int Limit { get; set; }
        [AliasAs("convert")]
        public string Convert { get; } = "USD";
    }
}

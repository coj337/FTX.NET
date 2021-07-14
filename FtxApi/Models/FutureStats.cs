
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class FutureStats
    {
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("nextFundingRate")]
        public decimal NextFundingRate { get; set; }

        [JsonProperty("nextFundingTime")]
        public string NextFundingTime { get; set; }

        [JsonProperty("expirationPrice")]
        public decimal ExpirationPrice { get; set; }

        [JsonProperty("predictedExpirationPrice")]
        public decimal PredictedExpirationPrice { get; set; }

        [JsonProperty("openInterest")]
        public decimal OpenInterest { get; set; }

        [JsonProperty("strikePrice")]
        public decimal StrikePrice { get; set; }
    }
}

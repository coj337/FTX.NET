
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class FutureStats
    {
        [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Volume { get; set; }

        [JsonProperty("nextFundingRate", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? NextFundingRate { get; set; }

        [JsonProperty("nextFundingTime", NullValueHandling = NullValueHandling.Ignore)]
        public string NextFundingTime { get; set; }

        [JsonProperty("expirationPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ExpirationPrice { get; set; }

        [JsonProperty("predictedExpirationPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PredictedExpirationPrice { get; set; }

        [JsonProperty("openInterest", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? OpenInterest { get; set; }

        [JsonProperty("strikePrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? StrikePrice { get; set; }
    }
}

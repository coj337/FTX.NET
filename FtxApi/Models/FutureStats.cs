using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class FutureStats
    {
        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("nextFundingRate")]
        public decimal NextFundingRate { get; set; }

        [JsonPropertyName("nextFundingTime")]
        public string NextFundingTime { get; set; }

        [JsonPropertyName("expirationPrice")]
        public decimal ExpirationPrice { get; set; }

        [JsonPropertyName("predictedExpirationPrice")]
        public decimal PredictedExpirationPrice { get; set; }

        [JsonPropertyName("openInterest")]
        public decimal OpenInterest { get; set; }

        [JsonPropertyName("strikePrice")]
        public decimal StrikePrice { get; set; }
    }
}

using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class GetQuoteStatusResponse
    {
        [JsonProperty("baseCoin", NullValueHandling = NullValueHandling.Ignore)]
        public string BaseCoin { get; set; }

        [JsonProperty("cost", NullValueHandling = NullValueHandling.Ignore)]
        public double? Cost { get; set; }

        [JsonProperty("expired", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Expired { get; set; }

        [JsonProperty("expiry", NullValueHandling = NullValueHandling.Ignore)]
        public double? Expiry { get; set; }

        [JsonProperty("filled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Filled { get; set; }

        [JsonProperty("fromCoin", NullValueHandling = NullValueHandling.Ignore)]
        public string FromCoin { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("proceeds", NullValueHandling = NullValueHandling.Ignore)]
        public double? Proceeds { get; set; }

        [JsonProperty("quoteCoin", NullValueHandling = NullValueHandling.Ignore)]
        public string QuoteCoin { get; set; }

        [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
        public string Side { get; set; }

        [JsonProperty("toCoin", NullValueHandling = NullValueHandling.Ignore)]
        public string ToCoin { get; set; }
    }
}
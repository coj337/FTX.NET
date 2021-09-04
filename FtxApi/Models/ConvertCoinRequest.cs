using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class ConvertCoinRequest
    {
        [JsonProperty("fromCoin", NullValueHandling = NullValueHandling.Ignore)]
        public string FromCoin { get; set; }
        
        [JsonProperty("toCoin", NullValueHandling = NullValueHandling.Ignore)]
        public string ToCoin { get; set; }
        
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Size { get; set; }
    }
}
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class QuoteStatusRequest
    {
        [JsonProperty("market", NullValueHandling = NullValueHandling.Ignore)]
        public string Market { get; set; }
    }
}
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class RequestQuoteResponse
    {
        [JsonProperty("quoteId", NullValueHandling = NullValueHandling.Ignore)]
        public long QuoteId { get; set; }
    }
}
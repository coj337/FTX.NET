using FtxApi.Enums;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class CancelOrder
    {
        [JsonProperty("market", NullValueHandling = NullValueHandling.Ignore)]
        public string Market { get; set; }

        [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
        public SideType? Side { get; set; }
        
        [JsonProperty("conditionalOrdersOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConditionalOrdersOnly { get; set; }
        
        [JsonProperty("limitOrdersOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LimitOrdersOnly { get; set; }
    }
}
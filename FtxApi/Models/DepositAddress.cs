using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class DepositAddress
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}

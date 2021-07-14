using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class Coin
    {
        [JsonProperty("canDeposit")]
        public bool CanDeposit { get; set; }

        [JsonProperty("canWithdraw")]
        public bool CanWithdraw { get; set; }

        [JsonProperty("hasTag")]
        public bool HasTag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

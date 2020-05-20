using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class Coin
    {
        [JsonPropertyName("canDeposit")]
        public bool CanDeposit { get; set; }

        [JsonPropertyName("canWithdraw")]
        public bool CanWithdraw { get; set; }

        [JsonPropertyName("hasTag")]
        public bool HasTag { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

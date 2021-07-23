using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class Balance
    {
        [JsonProperty("coin")] public string Coin { get; set; }
        [JsonProperty("free")] public decimal Free { get; set; }
        [JsonProperty("spotBorrow")] public decimal SpotBorrow { get; set; }
        [JsonProperty("total")] public decimal Total { get; set; }
        [JsonProperty("usdValue")] public decimal UsdValue { get; set; }
        [JsonProperty("availableWithoutBorrow")]
        public decimal AvailableWithoutBorrow { get; set; }
    }
}
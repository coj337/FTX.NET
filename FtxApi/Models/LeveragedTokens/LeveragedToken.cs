using Newtonsoft.Json;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedToken
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("underlying")]
        public string Underlying { get; set; }

        [JsonProperty("outstanding")]
        public decimal Outstanding { get; set; }

        [JsonProperty("pricePerShare")]
        public decimal PricePerShare { get; set; }

        [JsonProperty("positionPerShare")]
        public decimal PositionPerShare { get; set; }

        [JsonProperty("underlyingMark")]
        public decimal UnderlyingMark { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("change1h")]
        public decimal Change1h { get; set; }

        [JsonProperty("change24h")]
        public decimal Change24h { get; set; }
    }
}

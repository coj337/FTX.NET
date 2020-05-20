using System.Text.Json.Serialization;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedToken
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        [JsonPropertyName("outstanding")]
        public decimal Outstanding { get; set; }

        [JsonPropertyName("pricePerShare")]
        public decimal PricePerShare { get; set; }

        [JsonPropertyName("positionPerShare")]
        public decimal PositionPerShare { get; set; }

        [JsonPropertyName("underlyingMark")]
        public decimal UnderlyingMark { get; set; }

        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonPropertyName("change1h")]
        public decimal Change1h { get; set; }

        [JsonPropertyName("change24h")]
        public decimal Change24h { get; set; }
    }
}

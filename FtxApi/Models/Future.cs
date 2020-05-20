using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class Future
    {
        [JsonPropertyName("ask")]
        public decimal Ask { get; set; }

        [JsonPropertyName("bid")]
        public decimal Bid { get; set; }

        [JsonPropertyName("change1h")]
        public decimal Change1h { get; set; }

        [JsonPropertyName("change24h")]
        public decimal Change24h { get; set; }

        [JsonPropertyName("changeBod")]
        public decimal ChangeBod { get; set; }

        [JsonPropertyName("volumeUsd24h")]
        public decimal VolumeUsd24h { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("expired")]
        public bool Expired { get; set; }

        [JsonPropertyName("expiry")]
        public string Expiry { get; set; }

        [JsonPropertyName("index")]
        public decimal Index { get; set; }

        [JsonPropertyName("imfFactor")]
        public decimal ImfFactor { get; set; }

        [JsonPropertyName("last")]
        public decimal Last { get; set; }

        [JsonPropertyName("lowerBound")]
        public decimal LowerBound { get; set; }

        [JsonPropertyName("mark")]
        public decimal Mark { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("perpetual")]
        public bool Perpetual { get; set; }

        [JsonPropertyName("positionLimitWeight")]
        public decimal PositionLimitWeight { get; set; }

        [JsonPropertyName("postOnly")]
        public bool PostOnly { get; set; }

        [JsonPropertyName("priceIncrement")]
        public decimal PriceIncrement { get; set; }

        [JsonPropertyName("sizeIcrement")]
        public decimal SizeIncrement { get; set; }

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        [JsonPropertyName("upperBound")]
        public decimal UpperBound { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenCreation
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("requestedSize")]
        public decimal RequestedSize { get; set; }

        [JsonPropertyName("pending")]
        public bool Pending { get; set; }

        [JsonPropertyName("createdSize")]
        public decimal CreatedSize { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("cost")]
        public decimal Cost { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("requestedAt")]
        public DateTime RequestedAt { get; set; }

        [JsonPropertyName("fulfilledAt")]
        public DateTime FulfilledAt { get; set; }
    }
}

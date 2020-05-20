using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenCreationRequest
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("requestedSize")]
        public decimal RequestedSize { get; set; }

        [JsonPropertyName("pending")]
        public bool Pending { get; set; }

        [JsonPropertyName("cost")]
        public decimal Cost { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("requestedAt")]
        public DateTime RequestedAt { get; set; }
    }
}

using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenRedemptionRequest
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("pending")]
        public bool Pending { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("proceeds")]
        public decimal Proceeds { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("requestedAt")]
        public DateTime RequestedAt { get; set; }

        [JsonPropertyName("fulfilledAt")]
        public DateTime FulfilledAt { get; set; }
    }
}

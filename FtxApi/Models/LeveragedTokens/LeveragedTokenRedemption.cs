using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenRedemption
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("projectedProceeds")]
        public decimal ProjectedProceeds { get; set; }

        [JsonPropertyName("pending")]
        public bool Pending { get; set; }

        [JsonPropertyName("requestedAt")]
        public DateTime RequestedAt { get; set; }
    }
}

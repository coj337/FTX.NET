using System;
using Newtonsoft.Json;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenRedemptionRequest
    {
        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("proceeds")]
        public decimal Proceeds { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("requestedAt")]
        public DateTime RequestedAt { get; set; }

        [JsonProperty("fulfilledAt")]
        public DateTime FulfilledAt { get; set; }
    }
}

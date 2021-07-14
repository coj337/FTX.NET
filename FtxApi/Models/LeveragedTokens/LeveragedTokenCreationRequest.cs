using System;
using Newtonsoft.Json;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenCreationRequest
    {
        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("requestedSize")]
        public decimal RequestedSize { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("requestedAt")]
        public DateTime RequestedAt { get; set; }
    }
}

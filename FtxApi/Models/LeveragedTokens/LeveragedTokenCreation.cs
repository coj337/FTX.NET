using System;
using Newtonsoft.Json;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenCreation
    {
        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("requestedSize")]
        public decimal RequestedSize { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("createdSize")]
        public decimal CreatedSize { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("requestedAt")]
        public DateTime RequestedAt { get; set; }

        [JsonProperty("fulfilledAt")]
        public DateTime FulfilledAt { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenRedemption
    {
        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("projectedProceeds")]
        public decimal ProjectedProceeds { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("requestedAt")]
        public DateTime RequestedAt { get; set; }
    }
}

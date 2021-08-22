using System;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class ExpiredFutures
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("underlying", NullValueHandling = NullValueHandling.Ignore)]
        public string Underlying { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public FutureType? FutureType { get; set; }

        [JsonProperty("expiry", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Expiry { get; set; }

        [JsonProperty("perpetual", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Perpetual { get; set; }

        [JsonProperty("expired", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Expired { get; set; }

        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        [JsonProperty("postOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PostOnly { get; set; }

        [JsonProperty("priceIncrement", NullValueHandling = NullValueHandling.Ignore)]
        public double? PriceIncrement { get; set; }

        [JsonProperty("sizeIncrement", NullValueHandling = NullValueHandling.Ignore)]
        public long? SizeIncrement { get; set; }

        [JsonProperty("last", NullValueHandling = NullValueHandling.Ignore)] public double? Last { get; set; }

        [JsonProperty("bid", NullValueHandling = NullValueHandling.Ignore)] public double? Bid { get; set; }

        [JsonProperty("ask", NullValueHandling = NullValueHandling.Ignore)] public double? Ask { get; set; }

        [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
        public double? Index { get; set; }

        [JsonProperty("mark", NullValueHandling = NullValueHandling.Ignore)]
        public double? Mark { get; set; }

        [JsonProperty("imfFactor", NullValueHandling = NullValueHandling.Ignore)]
        public double? ImfFactor { get; set; }

        [JsonProperty("lowerBound", NullValueHandling = NullValueHandling.Ignore)]
        public double? LowerBound { get; set; }

        [JsonProperty("upperBound", NullValueHandling = NullValueHandling.Ignore)]
        public double? UpperBound { get; set; }

        [JsonProperty("underlyingDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string UnderlyingDescription { get; set; }

        [JsonProperty("expiryDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiryDescription { get; set; }

        [JsonProperty("moveStart", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? MoveStart { get; set; }

        [JsonProperty("marginPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? MarginPrice { get; set; }

        [JsonProperty("positionLimitWeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? PositionLimitWeight { get; set; }

        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)] public Group Group { get; set; }

    }
}
using System;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class Future
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("underlying")]
        public string Underlying { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public FutureType FutureType { get; set; }

        [JsonProperty("expiry")]
        public DateTimeOffset? Expiry { get; set; }

        [JsonProperty("perpetual")]
        public bool Perpetual { get; set; }

        [JsonProperty("expired")]
        public bool Expired { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("postOnly")]
        public bool PostOnly { get; set; }

        [JsonProperty("priceIncrement")]
        public double PriceIncrement { get; set; }

        [JsonProperty("sizeIncrement")]
        public double SizeIncrement { get; set; }

        [JsonProperty("last")]
        public double? Last { get; set; }

        [JsonProperty("bid")]
        public double? Bid { get; set; }

        [JsonProperty("ask")]
        public double? Ask { get; set; }

        [JsonProperty("index")]
        public double Index { get; set; }

        [JsonProperty("mark")]
        public double Mark { get; set; }

        [JsonProperty("imfFactor")]
        public double ImfFactor { get; set; }

        [JsonProperty("lowerBound")]
        public double LowerBound { get; set; }

        [JsonProperty("upperBound")]
        public double UpperBound { get; set; }

        [JsonProperty("underlyingDescription")]
        public string UnderlyingDescription { get; set; }

        [JsonProperty("expiryDescription")]
        public string ExpiryDescription { get; set; }

        [JsonProperty("moveStart")]
        public DateTimeOffset? MoveStart { get; set; }

        [JsonProperty("marginPrice")]
        public double MarginPrice { get; set; }

        [JsonProperty("positionLimitWeight")]
        public double PositionLimitWeight { get; set; }

        [JsonProperty("group")]
        public Group Group { get; set; }

        [JsonProperty("change1h")]
        public double Change1H { get; set; }

        [JsonProperty("change24h")]
        public double Change24H { get; set; }

        [JsonProperty("changeBod")]
        public double ChangeBod { get; set; }

        [JsonProperty("volumeUsd24h")]
        public double VolumeUsd24H { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("openInterest")]
        public double OpenInterest { get; set; }

        [JsonProperty("openInterestUsd")]
        public double OpenInterestUsd { get; set; }
    }
    
    public enum Group { Daily, Monthly, Perpetual, Prediction, Quarterly, Weekly };

    public enum FutureType { Future, Move, Perpetual, Prediction };
}
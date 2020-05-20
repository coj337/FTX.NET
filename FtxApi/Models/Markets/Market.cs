using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FtxApi.Models.Markets
{
    public class Market
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        [JsonPropertyName("baseCurrency")]
        public string BaseCurreny { get; set; }

        [JsonPropertyName("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("ask")]
        public decimal? Ask { get; set; }

        [JsonPropertyName("bid")]
        public decimal? Bid { get; set; }

        [JsonPropertyName("last")]
        public decimal? Last { get; set; }

        [JsonPropertyName("priceIncrement")]
        public decimal? PriceIncrement { get; set; }

        [JsonPropertyName("sizeIncrement")]
        public decimal? SizeIncrement { get; set; }
    }
}

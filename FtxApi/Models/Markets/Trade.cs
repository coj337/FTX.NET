using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FtxApi.Models.Markets
{
    public class Trade
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("liquidation")]
        public bool Liquidation { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }
}

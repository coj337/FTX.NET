using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FtxApi.Models.Markets
{
    public class Trade
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Id { get; set; }

        [JsonProperty("liquidation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Liquidation { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Price { get; set; }

        [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
        public string Side { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Size { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Time { get; set; }
    }
}
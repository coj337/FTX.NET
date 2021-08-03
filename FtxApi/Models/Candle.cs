using Utf8Json;
using System;
using System.Globalization;
using FtxApi.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace FtxApi.Models
{
    public class Candle
    {
        [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Close { get; set; }

        [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
        public decimal High { get; set; }

        [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Low { get; set; }

        [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Open { get; set; }

        [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime StartTime { get; set; }
        
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long Time { get; set; }

        [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Volume { get; set; }
    }
}
using Utf8Json;
using System;
using Newtonsoft.Json;


namespace FtxApi.Models
{
    public class Candle
    {
        [JsonProperty("close")]
        public decimal Close { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }
    }
}

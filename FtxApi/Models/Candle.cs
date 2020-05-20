using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class Candle
    {
        [JsonPropertyName("close")]
        public decimal Close { get; set; }

        [JsonPropertyName("high")]
        public decimal High { get; set; }

        [JsonPropertyName("low")]
        public decimal Low { get; set; }

        [JsonPropertyName("open")]
        public decimal Open { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }
    }
}

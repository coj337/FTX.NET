using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class FundingRate
    {
        [JsonPropertyName("future")]
        public string Future { get; set; }

        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }
}

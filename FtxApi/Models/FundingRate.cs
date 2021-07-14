using System;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class FundingRate
    {
        [JsonProperty("future")]
        public string Future { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class FundingPayment
    {
        [JsonProperty("future")]
        public string Future { get; set; }

        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("payment")]
        public decimal Payment { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}

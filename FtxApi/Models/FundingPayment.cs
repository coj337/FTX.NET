using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class FundingPayment
    {
        [JsonPropertyName("future")]
        public string Future { get; set; }

        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("payment")]
        public decimal Payment { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }
}

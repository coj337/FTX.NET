using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class OrderStatus
    {
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("filledSize")]
        public decimal? FilledSize { get; set; }

        [JsonPropertyName("future")]
        public string Future { get; set; }

        [JsonPropertyName("id")]
        public decimal? Id { get; set; }

        [JsonPropertyName("market")]
        public string Market { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("avgFillPrice")]
        public decimal? AvgFillPrice { get; set; }

        [JsonPropertyName("remainingSize")]
        public decimal? RemainingSize { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("size")]
        public decimal? Size { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }

        [JsonPropertyName("ioc")]
        public bool Ioc { get; set; }

        [JsonPropertyName("postOnly")]
        public bool PostOnly { get; set; }

        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
    }
}

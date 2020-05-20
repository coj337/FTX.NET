using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class TriggerOrder
    {
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("future")]
        public string Future { get; set; }

        [JsonPropertyName("id")]
        public decimal? Id { get; set; }

        [JsonPropertyName("market")]
        public string Market { get; set; }

        [JsonPropertyName("triggerPrice")]
        public decimal? TriggerPrice { get; set; }

        [JsonPropertyName("orderId")]
        public decimal? OrderId { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("size")]
        public decimal? Size { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("orderPrice")]
        public decimal? OrderPrice { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("triggeredAt")]
        public DateTime? TriggeredAt { get; set; }

        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }

        [JsonPropertyName("orderType")]
        public string OrderType { get; set; }

        [JsonPropertyName("retryUntilFilled")]
        public bool RetryUntilFilled { get; set; }
    }
}

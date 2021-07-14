using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class TriggerOrder
    {
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("future")]
        public string Future { get; set; }

        [JsonProperty("id")]
        public decimal? Id { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("triggerPrice")]
        public decimal? TriggerPrice { get; set; }

        [JsonProperty("orderId")]
        public decimal? OrderId { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("size")]
        public decimal? Size { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("orderPrice")]
        public decimal? OrderPrice { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("triggeredAt")]
        public DateTime? TriggeredAt { get; set; }

        [JsonProperty("reduceOnly")]
        public bool ReduceOnly { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("retryUntilFilled")]
        public bool RetryUntilFilled { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FtxApi.Enums;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class Order
    {
        [JsonProperty("createdAt")] public DateTime? CreatedAt { get; set; }

        [JsonProperty("filledSize")] public decimal? FilledSize { get; set; }

        [JsonProperty("future")] public string Future { get; set; }

        [JsonProperty("id")] public decimal? Id { get; set; }

        [JsonProperty("Market")] public string Market { get; set; }

        [JsonProperty("price")] public decimal? Price { get; set; }

        [JsonProperty("remainingSize")] public decimal? RemainingSize { get; set; }

        [JsonProperty("side")] public SideType Side { get; set; }

        [JsonProperty("size")] public decimal? Size { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("type")] public OrderType? Type { get; set; }

        [JsonProperty("reduceOnly")] public bool? ReduceOnly { get; set; }

        [JsonProperty("ioc")] public bool? Ioc { get; set; }

        [JsonProperty("postOnly")] public bool? PostOnly { get; set; }

        [JsonProperty("clientId")] public string ClientId { get; set; }

        
    }
}
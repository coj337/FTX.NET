using System;
using FtxApi.Enums;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class CreateOrder
    {
        [JsonProperty("market", NullValueHandling = NullValueHandling.Ignore)]
        public string Market { get; set; }

        [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
        public SideType Side { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Price { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Size { get; set; }

        [JsonProperty("triggerPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TriggerPrice { get; set; }

        [JsonProperty("orderPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? OrderPrice { get; set; }

        [JsonProperty("trailValue", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TrailValue { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public OrderType Type { get; set; }

        [JsonProperty("ioc", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ioc { get; set; }

        [JsonProperty("postOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PostOnly { get; set; }

        [JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; set; }

        [JsonProperty("reduceOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReduceOnly { get; set; }

        [JsonProperty("retryUntilFilled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RetryUntilFilled { get; set; }

        public DateTime Timestamp { get; set; }

        public CreateOrder(string market, SideType side, OrderType orderType, decimal triggerPrice, decimal amount,
            bool reduceOnly = false)
        {
            Market = market;
            Side = side;
            Type = orderType;
            TriggerPrice = triggerPrice;
            Size = amount;
            ReduceOnly = reduceOnly;
        }

        public CreateOrder(string market, SideType side, OrderType orderType, decimal triggerPrice, decimal orderPrice,
            decimal amount,
            bool reduceOnly = false)
        {
            Market = market;
            Side = side;
            Type = orderType;
            TriggerPrice = triggerPrice;
            OrderPrice = orderPrice;
            Size = amount;
            ReduceOnly = reduceOnly;
        }

        public CreateOrder(string market, SideType side, decimal price,
            OrderType orderType, decimal amount, string clientId = "", bool ioc = false, bool postOnly = false,
            bool reduceOnly = false)
        {
            Market = market;
            Side = side;
            Price = price;
            Type = orderType;
            Size = amount;
            ClientId = clientId;
            Ioc = ioc;
            PostOnly = postOnly;
            ReduceOnly = reduceOnly;
        }

        public CreateOrder()
        {
        }
    }
}
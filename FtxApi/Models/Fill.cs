using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class Fill
    {
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("feeRate")]
        public decimal FeeRate { get; set; }

        [JsonProperty("future")]
        public string Future { get; set; }

        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("liquidity")]
        public string Liquidity { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonProperty("orderId")]
        public decimal? OrderId { get; set; }

        [JsonProperty("tradeId")]
        public decimal? TradeId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

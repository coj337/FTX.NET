using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class Fill
    {
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonPropertyName("feeRate")]
        public decimal FeeRate { get; set; }

        [JsonPropertyName("future")]
        public string Future { get; set; }

        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("liquidity")]
        public string Liquidity { get; set; }

        [JsonPropertyName("market")]
        public string Market { get; set; }

        [JsonPropertyName("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName("orderId")]
        public decimal? OrderId { get; set; }

        [JsonPropertyName("tradeId")]
        public decimal? TradeId { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}

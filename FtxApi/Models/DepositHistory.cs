using System;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class DepositHistory
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("confirmations")]
        public decimal Confirmations { get; set; }

        [JsonPropertyName("confirmedTime")]
        public DateTime ConfirmedTime { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("sentTime")]
        public DateTime SentTime { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("txid")]
        public string TxId { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class DepositHistory
    {
        [JsonProperty("coin")]
        public string Coin { get; set; }

        [JsonProperty("confirmations")]
        public decimal Confirmations { get; set; }

        [JsonProperty("confirmedTime")]
        public DateTime ConfirmedTime { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("sentTime")]
        public DateTime SentTime { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}

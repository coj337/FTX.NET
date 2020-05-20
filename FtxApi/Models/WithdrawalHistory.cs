using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class WithdrawalHistory
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("txid")]
        public string TxId { get; set; }
    }
}

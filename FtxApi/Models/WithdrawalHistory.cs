using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class WithdrawalHistory
    {
        [JsonProperty("coin")]
        public string Coin { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("id")]
        public decimal Id { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }
    }
}

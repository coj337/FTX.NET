using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class Balance
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("free")]
        public decimal Free { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}

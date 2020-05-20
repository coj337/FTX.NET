using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class DepositAddress
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}

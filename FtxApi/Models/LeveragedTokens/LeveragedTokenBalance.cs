using System.Text.Json.Serialization;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenBalance
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
    }
}

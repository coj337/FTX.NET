
using Newtonsoft.Json;

namespace FtxApi.Models.LeveragedTokens
{
    public class LeveragedTokenBalance
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }
    }
}

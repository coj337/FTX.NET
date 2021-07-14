using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class AccountLeverage
    {
        [JsonProperty("leverage")]
        public int Leverage { get; set; }
    }
}

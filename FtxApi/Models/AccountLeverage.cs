using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class AccountLeverage
    {
        [JsonPropertyName("leverage")]
        public int Leverage { get; set; }
    }
}

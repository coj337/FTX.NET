using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class FtxResult<T>
    {

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("result")]
        public T Result { get; set; }
    }
}

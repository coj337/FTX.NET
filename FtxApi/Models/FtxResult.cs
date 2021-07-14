using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class FtxResult<T>
    {

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}

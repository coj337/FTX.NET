using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class ConvertAcceptResponse
    {
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public string Success { get; set; }
        
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public string Result { get; set; }
    }
}
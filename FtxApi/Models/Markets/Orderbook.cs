using System.Collections.Generic;
using Newtonsoft.Json;

namespace FtxApi.Models.Markets
{
    public class Orderbook
    {
        [JsonProperty("bids")]
        public List<List<decimal>> Bids { get; set; }

        [JsonProperty("asks")]
        public List<List<decimal>> Asks { get; set; }
    }
}

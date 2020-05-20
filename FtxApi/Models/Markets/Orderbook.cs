using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FtxApi.Models.Markets
{
    public class Orderbook
    {
        [JsonPropertyName("bids")]
        public List<List<decimal>> Bids { get; set; }

        [JsonPropertyName("asks")]
        public List<List<decimal>> Asks { get; set; }
    }
}

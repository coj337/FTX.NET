using System.Collections.Generic;
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class AccountInfo
    {
        [JsonProperty("backstopProvider")]
        public bool BackstopProvider { get; set; }

        [JsonProperty("collateral")]
        public decimal Collateral { get; set; }

        [JsonProperty("freeCollateral")]
        public decimal FreeCollateral { get; set; }

        [JsonProperty("initialMarginRequirement")]
        public decimal InitialMarginRequirement { get; set; }

        [JsonProperty("liquidating")]
        public bool Liquidating { get; set; }

        [JsonProperty("maintenanceMarginRequirement")]
        public decimal MaintenanceMarginRequirement { get; set; }

        [JsonProperty("makerFee")]
        public decimal MakerFee { get; set; }

        [JsonProperty("marginFraction")]
        public decimal? MarginFraction { get; set; }

        [JsonProperty("openMarginFraction")]
        public decimal? OpenMarginFraction { get; set; }

        [JsonProperty("takerFee")]
        public decimal TakerFee { get; set; }

        [JsonProperty("totalAccountValue")]
        public decimal TotalAccountValue { get; set; }

        [JsonProperty("totalPositionSize")]
        public decimal TotalPositionSize { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }

        [JsonProperty("positions")]
        public List<Position> Positions { get; set; }
    }
}

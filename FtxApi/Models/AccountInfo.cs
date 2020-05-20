using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class AccountInfo
    {
        [JsonPropertyName("backstopProvider")]
        public bool BackstopProvider { get; set; }

        [JsonPropertyName("collateral")]
        public decimal Collateral { get; set; }

        [JsonPropertyName("freeCollateral")]
        public decimal FreeCollateral { get; set; }

        [JsonPropertyName("initialMarginRequirement")]
        public decimal InitialMarginRequirement { get; set; }

        [JsonPropertyName("liquidating")]
        public bool Liquidating { get; set; }

        [JsonPropertyName("maintenanceMarginRequirement")]
        public decimal MaintenanceMarginRequirement { get; set; }

        [JsonPropertyName("makerFee")]
        public decimal MakerFee { get; set; }

        [JsonPropertyName("marginFraction")]
        public decimal? MarginFraction { get; set; }

        [JsonPropertyName("openMarginFraction")]
        public decimal? OpenMarginFraction { get; set; }

        [JsonPropertyName("takerFee")]
        public decimal TakerFee { get; set; }

        [JsonPropertyName("totalAccountValue")]
        public decimal TotalAccountValue { get; set; }

        [JsonPropertyName("totalPositionSize")]
        public decimal TotalPositionSize { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }

        [JsonPropertyName("positions")]
        public List<Position> Positions { get; set; }
    }
}


using System.Text.Json.Serialization;

namespace FtxApi.Models
{
    public class Position
    {
        [JsonPropertyName("collateralUsed")]
        public decimal? CollateralUsed { get; set; }

        [JsonPropertyName("cost")]
        public decimal? Cost { get; set; }

        [JsonPropertyName("entryPrice")]
        public decimal? EntryPrice { get; set; }

        [JsonPropertyName("estimatedLiquidationPrice")]
        public decimal? EstimatedLiquidationPrice { get; set; }

        [JsonPropertyName("future")]
        public string Future { get; set; }

        [JsonPropertyName("initialMarginRequirement")]
        public decimal? InitialMarginRequirement { get; set; }

        [JsonPropertyName("longOrderSize")]
        public decimal? LongOrderSize { get; set; }

        [JsonPropertyName("maintenanceMarginRequirement")]
        public decimal? MaintenanceMarginRequirement { get; set; }

        [JsonPropertyName("netSize")]
        public decimal? NetSize { get; set; }

        [JsonPropertyName("openSize")]
        public decimal? OpenSize { get; set; }

        [JsonPropertyName("realizedPnl")]
        public decimal? RealizedPnl { get; set; }

        [JsonPropertyName("shortOrderSize")]
        public decimal? ShortOrderSize { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("size")]
        public decimal? Size { get; set; }

        [JsonPropertyName("unrealizedPnl")]
        public decimal? UnrealizedPnl { get; set; }
    }
}

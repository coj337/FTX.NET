
using Newtonsoft.Json;

namespace FtxApi.Models
{
    public class Position
    {
        [JsonProperty("collateralUsed")]
        public decimal? CollateralUsed { get; set; }

        [JsonProperty("cost")]
        public decimal? Cost { get; set; }

        [JsonProperty("entryPrice")]
        public decimal? EntryPrice { get; set; }

        [JsonProperty("estimatedLiquidationPrice")]
        public decimal? EstimatedLiquidationPrice { get; set; }

        [JsonProperty("future")]
        public string Future { get; set; }

        [JsonProperty("initialMarginRequirement")]
        public decimal? InitialMarginRequirement { get; set; }

        [JsonProperty("longOrderSize")]
        public decimal? LongOrderSize { get; set; }

        [JsonProperty("maintenanceMarginRequirement")]
        public decimal? MaintenanceMarginRequirement { get; set; }

        [JsonProperty("netSize")]
        public decimal? NetSize { get; set; }

        [JsonProperty("openSize")]
        public decimal? OpenSize { get; set; }

        [JsonProperty("realizedPnl")]
        public decimal? RealizedPnl { get; set; }

        [JsonProperty("shortOrderSize")]
        public decimal? ShortOrderSize { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("size")]
        public decimal? Size { get; set; }

        [JsonProperty("unrealizedPnl")]
        public decimal? UnrealizedPnl { get; set; }
        
        [JsonProperty("recentAverageOpenPrice")]
        public decimal? AverageOpenPrice { get; set; }
    }
}

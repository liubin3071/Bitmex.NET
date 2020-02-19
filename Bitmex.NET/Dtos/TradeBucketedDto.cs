using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class TradeBucketedDto
    {
        [JsonPropertyName("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("open")]
        public decimal? Open { get; set; }

        [JsonPropertyName("high")]
        public decimal? High { get; set; }

        [JsonPropertyName("low")]
        public decimal? Low { get; set; }

        [JsonPropertyName("close")]
        public decimal? Close { get; set; }

        [JsonPropertyName("trades")]
        public decimal Trades { get; set; }

        [JsonPropertyName("volume")]
        public decimal? Volume { get; set; }

        [JsonPropertyName("vwap")]
        public decimal? Vwap { get; set; }

        [JsonPropertyName("lastSize")]
        public decimal? LastSize { get; set; }

        [JsonPropertyName("turnover")]
        public decimal Turnover { get; set; }

        [JsonPropertyName("homeNotional")]
        public decimal HomeNotional { get; set; }

        [JsonPropertyName("foreignNotional")]
        public decimal ForeignNotional { get; set; }
    }
}
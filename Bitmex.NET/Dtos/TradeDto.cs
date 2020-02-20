using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class TradeDto
    {
        [JsonPropertyName("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("tickDirection")]
        public string TickDirection { get; set; }

        [JsonPropertyName("trdMatchID")]
        public string TrdMatchId { get; set; }

        [JsonPropertyName("grossValue")]
        public decimal? GrossValue { get; set; }

        [JsonPropertyName("homeNotional")]
        public decimal? HomeNotional { get; set; }

        [JsonPropertyName("foreignNotional")]
        public decimal? ForeignNotional { get; set; }
    }
}
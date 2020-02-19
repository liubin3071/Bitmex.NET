using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class InstrumentCompositeIndexDto
    {
        [JsonPropertyName("timestamp")]
        public System.DateTimeOffset? Timestamp { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("indexSymbol")]
        public string IndexSymbol { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("lastPrice")]
        public decimal? LastPrice { get; set; }

        [JsonPropertyName("weight")]
        public decimal? Weight { get; set; }

        [JsonPropertyName("logged")]
        public System.DateTimeOffset? Logged { get; set; }
    }
}
using System.Text.Json.Serialization;
using System;

namespace Bitmex.NET.Dtos
{
    public class StatsHistoryDto
    {
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("volume")]
        public decimal? Volume { get; set; }

        [JsonPropertyName("turnover")]
        public decimal? Turnover { get; set; }
    }
}

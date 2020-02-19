using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    [DebuggerDisplay("{Timestamp} {Symbol}")]
    public partial class QuoteDto
    {
        [JsonPropertyName("timestamp")]
        public System.DateTimeOffset? Timestamp { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("bidSize")]
        public long? BidSize { get; set; }

        [JsonPropertyName("bidPrice")]
        public decimal? BidPrice { get; set; }

        [JsonPropertyName("askPrice")]
        public decimal? AskPrice { get; set; }

        [JsonPropertyName("askSize")]
        public long? AskSize { get; set; }
    }
}
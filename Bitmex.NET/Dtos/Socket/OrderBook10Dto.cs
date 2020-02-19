using System.Text.Json.Serialization;
using System;

namespace Bitmex.NET.Dtos.Socket
{
    public class OrderBook10Dto
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("bids")]
        public decimal[][] Bids { get; set; }

        [JsonPropertyName("asks")]
        public decimal[][] Asks { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTimeOffset? Timestamp { get; set; }
    }
}
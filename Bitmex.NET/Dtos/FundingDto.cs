using System;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class FundingDto
    {
        [JsonPropertyName("timestamp")]
        public DateTime? Timestamp { get; set; } = null;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("fundingInterval")]
        public DateTime? FundingInterval { get; set; } = null;

        [JsonPropertyName("fundingRate")]
        public double? FundingRate { get; set; }

        [JsonPropertyName("fundingRateDaily")]
        public double? FundingRateDaily { get; set; }
    }
}
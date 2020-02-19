using System;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class InsuranceDto
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonPropertyName("walletBalance")]
        public decimal? WalletBalance { get; set; }
    }
}
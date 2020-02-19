using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace Bitmex.NET.Dtos
{
    public class StatsDto
    {
        [JsonPropertyName("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("volume24h")]
        public decimal? Volume24H { get; set; }

        [JsonPropertyName("turnover24h")]
        public decimal? Turnover24H { get; set; }

        [JsonPropertyName("openInterest")]
        public decimal? OpenInterest { get; set; }

        [JsonPropertyName("openValue")]
        public decimal? OpenValue { get; set; }
    }
}

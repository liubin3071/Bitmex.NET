using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace Bitmex.NET.Dtos
{
    public class StatsHistoryUsdDto
    {
        [JsonPropertyName("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("turnover24h")]
        public decimal? Turnover24h { get; set; }

        [JsonPropertyName("turnover30d")]
        public decimal? Turnover30d { get; set; }

        [JsonPropertyName("turnover365d")]
        public decimal? Turnover365d { get; set; }

        [JsonPropertyName("turnover")]
        public decimal? Turnover { get; set; }

       
  

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class SettlementDto
    {
        [JsonPropertyName("timestamp")]
        public DateTime? TimeStamp { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("settlementType")]
        public string SettlementType { get; set; }
        [JsonPropertyName("settledPrice")]
        public decimal? SettledPrice { get; set; }
        [JsonPropertyName("optionStrikePrice")]
        public decimal? OptionStrikePrice { get; set; }
        [JsonPropertyName("optionUnderlyingPrice")]
        public decimal? OptionUnderlyingPrice { get; set; }
        [JsonPropertyName("bankrupt")]
        public decimal? Bankrupt { get; set; }
        [JsonPropertyName("taxBase")]
        public decimal? TaxBase { get; set; }
        [JsonPropertyName("taxRate")]
        public decimal? TaxRate { get; set; }
    }
}

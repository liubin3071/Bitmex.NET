using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    [DebuggerDisplay("{Symbol} {Side} {OrderQty}")]
    public class OrderDto
    {
        [JsonPropertyName("orderID")]
        public string OrderId { get; set; }

        [JsonPropertyName("clOrdID")]
        public string ClOrdId { get; set; }

        [JsonPropertyName("clOrdLinkID")]
        public string ClOrdLinkId { get; set; }

        [JsonPropertyName("account")]
        public long? Account { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("orderQty")]
        public decimal? OrderQty { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("displayQty")]
        public decimal? DisplayQty { get; set; }

        [JsonPropertyName("stopPx")]
        public decimal? StopPx { get; set; }

        [JsonPropertyName("pegOffsetValue")]
        public decimal? PegOffsetValue { get; set; }

        [JsonPropertyName("pegPriceType")]
        public string PegPriceType { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("settlCurrency")]
        public string SettlCurrency { get; set; }

        [JsonPropertyName("ordType")]
        public string OrdType { get; set; }

        [JsonPropertyName("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("execInst")]
        public string ExecInst { get; set; }

        [JsonPropertyName("exDestination")]
        public string ExDestination { get; set; }

        [JsonPropertyName("ordStatus")]
        public string OrdStatus { get; set; }

        [JsonPropertyName("triggered")]
        public string Triggered { get; set; }

        [JsonPropertyName("workingIndicator")]
        public bool WorkingIndicator { get; set; }

        [JsonPropertyName("ordRejReason")]
        public string OrdRejReason { get; set; }

        [JsonPropertyName("leavesQty")]
        public decimal? LeavesQty { get; set; }

        [JsonPropertyName("cumQty")]
        public decimal CumQty { get; set; }

        [JsonPropertyName("avgPx")]
        public decimal? AvgPx { get; set; }

        [JsonPropertyName("multiLegReportingType")]
        public string MultiLegReportingType { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("transactTime")]
        public System.DateTimeOffset TransactTime { get; set; }

        [JsonPropertyName("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }
    }
}
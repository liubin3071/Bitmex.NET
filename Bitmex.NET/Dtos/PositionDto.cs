using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    [DebuggerDisplay("{Symbol} {ExecQty} Unr. P&L{UnrealisedPnl}")]
    public partial class PositionDto
    {
        [JsonPropertyName("account")]
        public long Account { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        [JsonPropertyName("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName("commission")]
        public decimal Commission { get; set; }

        [JsonPropertyName("initMarginReq")]
        public decimal InitMarginReq { get; set; }

        [JsonPropertyName("maintMarginReq")]
        public decimal MaintMarginReq { get; set; }

        [JsonPropertyName("riskLimit")]
        public decimal RiskLimit { get; set; }

        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }

        [JsonPropertyName("crossMargin")]
        public bool CrossMargin { get; set; }

        [JsonPropertyName("deleveragePercentile")]
        public decimal? DeleveragePercentile { get; set; }

        [JsonPropertyName("rebalancedPnl")]
        public decimal RebalancedPnl { get; set; }

        [JsonPropertyName("prevRealisedPnl")]
        public decimal PrevRealisedPnl { get; set; }

        [JsonPropertyName("prevUnrealisedPnl")]
        public decimal PrevUnrealisedPnl { get; set; }

        [JsonPropertyName("prevClosePrice")]
        public decimal PrevClosePrice { get; set; }

        [JsonPropertyName("openingTimestamp")]
        public System.DateTimeOffset OpeningTimestamp { get; set; }

        [JsonPropertyName("openingQty")]
        public decimal OpeningQty { get; set; }

        [JsonPropertyName("openingCost")]
        public decimal OpeningCost { get; set; }

        [JsonPropertyName("openingComm")]
        public decimal OpeningComm { get; set; }

        [JsonPropertyName("openOrderBuyQty")]
        public decimal OpenOrderBuyQty { get; set; }

        [JsonPropertyName("openOrderBuyCost")]
        public decimal OpenOrderBuyCost { get; set; }

        [JsonPropertyName("openOrderBuyPremium")]
        public decimal OpenOrderBuyPremium { get; set; }

        [JsonPropertyName("openOrderSellQty")]
        public decimal OpenOrderSellQty { get; set; }

        [JsonPropertyName("openOrderSellCost")]
        public decimal OpenOrderSellCost { get; set; }

        [JsonPropertyName("openOrderSellPremium")]
        public decimal OpenOrderSellPremium { get; set; }

        [JsonPropertyName("execBuyQty")]
        public decimal ExecBuyQty { get; set; }

        [JsonPropertyName("execBuyCost")]
        public decimal ExecBuyCost { get; set; }

        [JsonPropertyName("execSellQty")]
        public decimal ExecSellQty { get; set; }

        [JsonPropertyName("execSellCost")]
        public decimal ExecSellCost { get; set; }

        [JsonPropertyName("execQty")]
        public decimal ExecQty { get; set; }

        [JsonPropertyName("execCost")]
        public decimal ExecCost { get; set; }

        [JsonPropertyName("execComm")]
        public decimal ExecComm { get; set; }

        [JsonPropertyName("currentTimestamp")]
        public System.DateTimeOffset CurrentTimestamp { get; set; }

        [JsonPropertyName("currentQty")]
        public decimal CurrentQty { get; set; }

        [JsonPropertyName("currentCost")]
        public decimal CurrentCost { get; set; }

        [JsonPropertyName("currentComm")]
        public decimal? CurrentComm { get; set; }

        [JsonPropertyName("realisedCost")]
        public decimal RealisedCost { get; set; }

        [JsonPropertyName("unrealisedCost")]
        public decimal UnrealisedCost { get; set; }

        [JsonPropertyName("grossOpenCost")]
        public decimal GrossOpenCost { get; set; }

        [JsonPropertyName("grossOpenPremium")]
        public decimal GrossOpenPremium { get; set; }

        [JsonPropertyName("grossExecCost")]
        public decimal GrossExecCost { get; set; }

        [JsonPropertyName("isOpen")]
        public bool IsOpen { get; set; }

        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }

        [JsonPropertyName("markValue")]
        public decimal MarkValue { get; set; }

        [JsonPropertyName("riskValue")]
        public decimal RiskValue { get; set; }

        [JsonPropertyName("homeNotional")]
        public decimal HomeNotional { get; set; }

        [JsonPropertyName("foreignNotional")]
        public decimal ForeignNotional { get; set; }

        [JsonPropertyName("posState")]
        public string PosState { get; set; }

        [JsonPropertyName("posCost")]
        public decimal PosCost { get; set; }

        [JsonPropertyName("posCost2")]
        public decimal PosCost2 { get; set; }

        [JsonPropertyName("posCross")]
        public decimal PosCross { get; set; }

        [JsonPropertyName("posInit")]
        public decimal PosInit { get; set; }

        [JsonPropertyName("posComm")]
        public decimal PosComm { get; set; }

        [JsonPropertyName("posLoss")]
        public decimal PosLoss { get; set; }

        [JsonPropertyName("posMargin")]
        public decimal PosMargin { get; set; }

        [JsonPropertyName("posMaint")]
        public decimal PosMaint { get; set; }

        [JsonPropertyName("posAllowance")]
        public decimal PosAllowance { get; set; }

        [JsonPropertyName("taxableMargin")]
        public decimal TaxableMargin { get; set; }

        [JsonPropertyName("initMargin")]
        public decimal InitMargin { get; set; }

        [JsonPropertyName("maintMargin")]
        public decimal MaintMargin { get; set; }

        [JsonPropertyName("sessionMargin")]
        public decimal SessionMargin { get; set; }

        [JsonPropertyName("targetExcessMargin")]
        public decimal TargetExcessMargin { get; set; }

        [JsonPropertyName("varMargin")]
        public decimal VarMargin { get; set; }

        [JsonPropertyName("realisedGrossPnl")]
        public decimal RealisedGrossPnl { get; set; }

        [JsonPropertyName("realisedTax")]
        public decimal RealisedTax { get; set; }

        [JsonPropertyName("realisedPnl")]
        public decimal RealisedPnl { get; set; }

        [JsonPropertyName("unrealisedGrossPnl")]
        public decimal UnrealisedGrossPnl { get; set; }

        [JsonPropertyName("longBankrupt")]
        public decimal LongBankrupt { get; set; }

        [JsonPropertyName("shortBankrupt")]
        public decimal ShortBankrupt { get; set; }

        [JsonPropertyName("taxBase")]
        public decimal TaxBase { get; set; }

        [JsonPropertyName("indicativeTaxRate")]
        public decimal? IndicativeTaxRate { get; set; }

        [JsonPropertyName("indicativeTax")]
        public decimal IndicativeTax { get; set; }

        [JsonPropertyName("unrealisedTax")]
        public decimal UnrealisedTax { get; set; }

        [JsonPropertyName("unrealisedPnl")]
        public decimal UnrealisedPnl { get; set; }

        [JsonPropertyName("unrealisedPnlPcnt")]
        public decimal UnrealisedPnlPcnt { get; set; }

        [JsonPropertyName("unrealisedRoePcnt")]
        public decimal UnrealisedRoePcnt { get; set; }

        [JsonPropertyName("avgCostPrice")]
        public decimal? AvgCostPrice { get; set; }

        [JsonPropertyName("avgEntryPrice")]
        public decimal? AvgEntryPrice { get; set; }

        [JsonPropertyName("breakEvenPrice")]
        public decimal? BreakEvenPrice { get; set; }

        [JsonPropertyName("marginCallPrice")]
        public decimal? MarginCallPrice { get; set; }

        [JsonPropertyName("liquidationPrice")]
        public decimal? LiquidationPrice { get; set; }

        [JsonPropertyName("bankruptPrice")]
        public decimal? BankruptPrice { get; set; }

        [JsonPropertyName("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("lastPrice")]
        public decimal? LastPrice { get; set; }

        [JsonPropertyName("lastValue")]
        public decimal LastValue { get; set; }
    }
}
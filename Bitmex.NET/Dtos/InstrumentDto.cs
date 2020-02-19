using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class InstrumentDto
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("typ")]
        public string Typ { get; set; }

        [JsonPropertyName("listing")]
        public System.DateTimeOffset? Listing { get; set; }

        [JsonPropertyName("front")]
        public System.DateTimeOffset? Front { get; set; }

        [JsonPropertyName("expiry")]
        public System.DateTimeOffset? Expiry { get; set; }

        [JsonPropertyName("settle")]
        public System.DateTimeOffset? Settle { get; set; }

        [JsonPropertyName("relistInterval")]
        public System.DateTimeOffset? RelistInterval { get; set; }

        [JsonPropertyName("inverseLeg")]
        public string InverseLeg { get; set; }

        [JsonPropertyName("sellLeg")]
        public string SellLeg { get; set; }

        [JsonPropertyName("buyLeg")]
        public string BuyLeg { get; set; }

        [JsonPropertyName("optionStrikePcnt")]
        public decimal? OptionStrikePcnt { get; set; }

        [JsonPropertyName("optionStrikeRound")]
        public decimal? OptionStrikeRound { get; set; }

        [JsonPropertyName("optionStrikePrice")]
        public decimal? OptionStrikePrice { get; set; }

        [JsonPropertyName("optionMultiplier")]
        public decimal? OptionMultiplier { get; set; }

        [JsonPropertyName("positionCurrency")]
        public string PositionCurrency { get; set; }

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; }

        [JsonPropertyName("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName("underlyingSymbol")]
        public string UnderlyingSymbol { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("referenceSymbol")]
        public string ReferenceSymbol { get; set; }

        [JsonPropertyName("calcInterval")]
        public System.DateTimeOffset? CalcInterval { get; set; }

        [JsonPropertyName("publishInterval")]
        public System.DateTimeOffset? PublishInterval { get; set; }

        [JsonPropertyName("publishTime")]
        public System.DateTimeOffset? PublishTime { get; set; }

        [JsonPropertyName("maxOrderQty")]
        public decimal? MaxOrderQty { get; set; }

        [JsonPropertyName("maxPrice")]
        public decimal? MaxPrice { get; set; }

        [JsonPropertyName("lotSize")]
        public decimal? LotSize { get; set; }

        [JsonPropertyName("tickSize")]
        public decimal? TickSize { get; set; }

        [JsonPropertyName("multiplier")]
        public decimal? Multiplier { get; set; }

        [JsonPropertyName("settlCurrency")]
        public string SettlCurrency { get; set; }

        [JsonPropertyName("underlyingToPositionMultiplier")]
        public decimal? UnderlyingToPositionMultiplier { get; set; }

        [JsonPropertyName("underlyingToSettleMultiplier")]
        public decimal? UnderlyingToSettleMultiplier { get; set; }

        [JsonPropertyName("quoteToSettleMultiplier")]
        public decimal? QuoteToSettleMultiplier { get; set; }

        [JsonPropertyName("isQuanto")]
        public bool? IsQuanto { get; set; }

        [JsonPropertyName("isInverse")]
        public bool? IsInverse { get; set; }

        [JsonPropertyName("initMargin")]
        public decimal? InitMargin { get; set; }

        [JsonPropertyName("maintMargin")]
        public decimal? MaintMargin { get; set; }

        [JsonPropertyName("riskLimit")]
        public decimal? RiskLimit { get; set; }

        [JsonPropertyName("riskStep")]
        public decimal? RiskStep { get; set; }

        [JsonPropertyName("limit")]
        public decimal? Limit { get; set; }

        [JsonPropertyName("capped")]
        public bool? Capped { get; set; }

        [JsonPropertyName("taxed")]
        public bool? Taxed { get; set; }

        [JsonPropertyName("deleverage")]
        public bool? Deleverage { get; set; }

        [JsonPropertyName("makerFee")]
        public decimal? MakerFee { get; set; }

        [JsonPropertyName("takerFee")]
        public decimal? TakerFee { get; set; }

        [JsonPropertyName("settlementFee")]
        public decimal? SettlementFee { get; set; }

        [JsonPropertyName("insuranceFee")]
        public decimal? InsuranceFee { get; set; }

        [JsonPropertyName("fundingBaseSymbol")]
        public string FundingBaseSymbol { get; set; }

        [JsonPropertyName("fundingQuoteSymbol")]
        public string FundingQuoteSymbol { get; set; }

        [JsonPropertyName("fundingPremiumSymbol")]
        public string FundingPremiumSymbol { get; set; }

        [JsonPropertyName("fundingTimestamp")]
        public System.DateTimeOffset? FundingTimestamp { get; set; }

        [JsonPropertyName("fundingInterval")]
        public System.DateTimeOffset? FundingInterval { get; set; }

        [JsonPropertyName("fundingRate")]
        public decimal? FundingRate { get; set; }

        [JsonPropertyName("indicativeFundingRate")]
        public decimal? IndicativeFundingRate { get; set; }

        [JsonPropertyName("rebalanceTimestamp")]
        public System.DateTimeOffset? RebalanceTimestamp { get; set; }

        [JsonPropertyName("rebalanceInterval")]
        public System.DateTimeOffset? RebalanceInterval { get; set; }

        [JsonPropertyName("openingTimestamp")]
        public System.DateTimeOffset? OpeningTimestamp { get; set; }

        [JsonPropertyName("closingTimestamp")]
        public System.DateTimeOffset? ClosingTimestamp { get; set; }

        [JsonPropertyName("sessionInterval")]
        public System.DateTimeOffset? SessionInterval { get; set; }

        [JsonPropertyName("prevClosePrice")]
        public decimal? PrevClosePrice { get; set; }

        [JsonPropertyName("limitDownPrice")]
        public decimal? LimitDownPrice { get; set; }

        [JsonPropertyName("limitUpPrice")]
        public decimal? LimitUpPrice { get; set; }

        [JsonPropertyName("bankruptLimitDownPrice")]
        public decimal? BankruptLimitDownPrice { get; set; }

        [JsonPropertyName("bankruptLimitUpPrice")]
        public decimal? BankruptLimitUpPrice { get; set; }

        [JsonPropertyName("prevTotalVolume")]
        public decimal? PrevTotalVolume { get; set; }

        [JsonPropertyName("totalVolume")]
        public decimal? TotalVolume { get; set; }

        [JsonPropertyName("volume")]
        public decimal? Volume { get; set; }

        [JsonPropertyName("volume24h")]
        public decimal? Volume24H { get; set; }

        [JsonPropertyName("prevTotalTurnover")]
        public decimal? PrevTotalTurnover { get; set; }

        [JsonPropertyName("totalTurnover")]
        public decimal? TotalTurnover { get; set; }

        [JsonPropertyName("turnover")]
        public decimal? Turnover { get; set; }

        [JsonPropertyName("turnover24h")]
        public decimal? Turnover24H { get; set; }

        [JsonPropertyName("prevPrice24h")]
        public decimal? PrevPrice24H { get; set; }

        [JsonPropertyName("vwap")]
        public decimal? Vwap { get; set; }

        [JsonPropertyName("highPrice")]
        public decimal? HighPrice { get; set; }

        [JsonPropertyName("lowPrice")]
        public decimal? LowPrice { get; set; }

        [JsonPropertyName("lastPrice")]
        public decimal? LastPrice { get; set; }

        [JsonPropertyName("lastPriceProtected")]
        public decimal? LastPriceProtected { get; set; }

        [JsonPropertyName("lastTickDirection")]
        public string LastTickDirection { get; set; }

        [JsonPropertyName("lastChangePcnt")]
        public decimal? LastChangePcnt { get; set; }

        [JsonPropertyName("bidPrice")]
        public decimal? BidPrice { get; set; }

        [JsonPropertyName("midPrice")]
        public decimal? MidPrice { get; set; }

        [JsonPropertyName("askPrice")]
        public decimal? AskPrice { get; set; }

        [JsonPropertyName("impactBidPrice")]
        public decimal? ImpactBidPrice { get; set; }

        [JsonPropertyName("impactMidPrice")]
        public decimal? ImpactMidPrice { get; set; }

        [JsonPropertyName("impactAskPrice")]
        public decimal? ImpactAskPrice { get; set; }

        [JsonPropertyName("hasLiquidity")]
        public bool? HasLiquidity { get; set; }

        [JsonPropertyName("openInterest")]
        public decimal? OpenInterest { get; set; }

        [JsonPropertyName("openValue")]
        public decimal? OpenValue { get; set; }

        [JsonPropertyName("fairMethod")]
        public string FairMethod { get; set; }

        [JsonPropertyName("fairBasisRate")]
        public decimal? FairBasisRate { get; set; }

        [JsonPropertyName("fairBasis")]
        public decimal? FairBasis { get; set; }

        [JsonPropertyName("fairPrice")]
        public decimal? FairPrice { get; set; }

        [JsonPropertyName("markMethod")]
        public string MarkMethod { get; set; }

        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }

        [JsonPropertyName("indicativeTaxRate")]
        public decimal? IndicativeTaxRate { get; set; }

        [JsonPropertyName("indicativeSettlePrice")]
        public decimal? IndicativeSettlePrice { get; set; }

        [JsonPropertyName("optionUnderlyingPrice")]
        public decimal? OptionUnderlyingPrice { get; set; }

        [JsonPropertyName("settledPrice")]
        public decimal? SettledPrice { get; set; }

        [JsonPropertyName("timestamp")]
        public System.DateTimeOffset? Timestamp { get; set; }
    }
}
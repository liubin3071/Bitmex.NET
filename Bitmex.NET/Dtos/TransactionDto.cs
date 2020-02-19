using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class TransactionDto
    {
        [JsonPropertyName("account")]
        public long? Account { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("transactType")]
        public string TransactType { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("amount")]
        public long? Amount { get; set; }

        [JsonPropertyName("pendingDebit")]
        public long? PendingDebit { get; set; }

        [JsonPropertyName("realisedPnl")]
        public long? RealisedPnl { get; set; }

        [JsonPropertyName("walletBalance")]
        public long? WalletBalance { get; set; }

        [JsonPropertyName("unrealisedPnl")]
        public long? UnrealisedPnl { get; set; }

        [JsonPropertyName("marginBalance")]
        public long? MarginBalance { get; set; }
    }
}
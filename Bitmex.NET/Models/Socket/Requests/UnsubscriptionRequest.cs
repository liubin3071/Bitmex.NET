using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket
{
    public sealed class UnsubscriptionRequest : OperationRequest
    {
        [JsonIgnore]
        public SubscriptionType UnsubscriptionType { get; }

        [JsonIgnore]
        public string? Symbol { get; }

        public UnsubscriptionRequest(SubscriptionType unsubscriptionType, string symbol)
            : base(OperationType.unsubscribe, $"{BitmexJsonSerializer.Serialize(unsubscriptionType).Trim('"')}:{symbol}")
        {
            UnsubscriptionType = unsubscriptionType;
            Symbol = symbol;
        }

        public UnsubscriptionRequest(SubscriptionType unsubscriptionType)
            : base(OperationType.unsubscribe, unsubscriptionType)
        {
            UnsubscriptionType = unsubscriptionType;
        }
    }
}
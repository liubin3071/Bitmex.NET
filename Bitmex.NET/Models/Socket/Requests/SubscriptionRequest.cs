using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket
{
    public sealed class SubscriptionRequest : OperationRequest
    {
        [JsonIgnore]
        public SubscriptionType SubscriptionType { get; }

        [JsonIgnore]
        public string? Symbol { get; }

        public SubscriptionRequest(SubscriptionType subscriptionType, string symbol)
            : base(OperationType.subscribe, $"{BitmexJsonSerializer.Serialize(subscriptionType).Trim('"')}:{symbol}")
        {
            SubscriptionType = subscriptionType;
            Symbol = symbol;
        }

        public SubscriptionRequest(SubscriptionType subscriptionType)
            : base(OperationType.subscribe, subscriptionType)
        {
            SubscriptionType = subscriptionType;
        }

        public UnsubscriptionRequest CreateUnsubscriptionRequest()
        {
            return new UnsubscriptionRequest(SubscriptionType, Symbol);
        }
    }
}
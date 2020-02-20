using Bitmex.NET.Authorization;
using System.Linq;
using Bitmex.NET.Models.Socket;

namespace CoinGroup.Market.Bitmex.Models.Websockets.Requests
{
    public static class BitmexSocketRequests
    {
        public static SocketRequest CreatePingRequest()
        {
            return new RawRequest("ping");
        }

        public static AuthorizationRequest CreateAuthorizationRequest(string apiKey, long expiresTime, string sign)
        {
            return new AuthorizationRequest(apiKey, expiresTime, sign);
        }

        public static OperationRequest CreateCancelAllAfterRequest(int timeout)
        {
            return new OperationRequest(OperationType.cancelAllAfter, timeout);
        }

        public static SubscriptionRequest CreateSubscriptionRequest(SubscriptionType subscriptionType)
        {
            return new SubscriptionRequest(subscriptionType);
        }

        public static SubscriptionRequest CreateSubscriptionRequest(SubscriptionType subscriptionType, string symbol)
        {
            return new SubscriptionRequest(subscriptionType: subscriptionType, symbol: symbol);
        }

        public static UnsubscriptionRequest CreateUnsubscriptionRequest(SubscriptionType subscriptionType)
        {
            return new UnsubscriptionRequest(subscriptionType);
        }

        public static UnsubscriptionRequest CreateUnsubscriptionRequest(SubscriptionType subscriptionType, string symbol)
        {
            return new UnsubscriptionRequest(subscriptionType, symbol);
        }
    }
}
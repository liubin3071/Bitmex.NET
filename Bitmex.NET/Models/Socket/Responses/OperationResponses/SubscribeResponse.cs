using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket.Responses.OperationResponses
{
    public class SubscribeResponse : OperationResponseBase
    {
        //{"success":true,"subscribe":"trade","request":{"op":"subscribe","args":["trade"]}}
        //public override OperationType Operation => OperationType.subscribe;

        public string? Subscribe { get; set; }

        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        internal static bool TryParse(JsonElement response, Action<SubscribeResponse> action)
        {
            if (response.TryGetProperty("subscribe", out _))
            {
                var subscribeResponse = BitmexJsonSerializer.Deserialize<SubscribeResponse>(response);
                action?.Invoke(subscribeResponse);
                return true;
            }
            return false;
        }
    }
}
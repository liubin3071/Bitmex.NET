using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket.Responses.OperationResponses
{
    //{"success":true,"unsubscribe":"tradeBin1m","request":{"op":"unsubscribe","args":["tradeBin1m"]}}
    public class UnsubscribeResponse : OperationResponseBase
    {
        //public override OperationType Operation => OperationType.unsubscribe;

        [JsonPropertyName("unsubscribe")]
        public string? Unsubscribe { get; set; }

        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        internal static bool TryParse(JsonElement response, Action<UnsubscribeResponse> action)
        {
            if (response.TryGetProperty("unsubscribe", out _))
            {
                var unsubscribeResponse = BitmexJsonSerializer.Deserialize<UnsubscribeResponse>(response);
                action?.Invoke(unsubscribeResponse);
                return true;
            }
            return false;
        }
    }
}
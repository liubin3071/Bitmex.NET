using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Bitmex.NET.Dtos.Socket;

namespace Bitmex.NET.Models.Socket.Responses.OperationResponses
{
    // 设置 60 秒的自动取消
    // {"op": "cancelAllAfter", "args": 60000}
    // {"now":"2015-09-02T14:18:43.536Z","cancelTime":"2015-09-02T14:19:43.536Z", "request":{"op":"cancelAllAfter","args":60000}}
    // 取消它
    // {"op": "cancelAllAfter", "args": 0}
    // {"now":"2015-09-02T14:19:11.617Z","cancelTime":0,"request":{"op":"cancelAllAfter","args":0}}
    public class CancelAllAfterResponse : OperationResponseBase
    {
        //public override OperationType Operation => OperationType.cancelAllAfter;

        [JsonPropertyName("now")]
        public DateTimeOffset? Now { get; set; }

        [JsonPropertyName("cancelTime")]
        public DateTimeOffset? CancelTime { get; set; }

        internal static bool TryHandle(JsonElement response, Action<CancelAllAfterResponse> action)
        {
            if (response.TryGetProperty("request", out var request)
                && request.TryGetProperty("op", out var op)
                && op.GetString() == "cancelAllAfter")
            {
                var cancelAllAfterResponse = BitmexJsonSerializer.Deserialize<CancelAllAfterResponse>(response);
                action?.Invoke(cancelAllAfterResponse);
                return true;
            }
            return false;
        }
    }
}
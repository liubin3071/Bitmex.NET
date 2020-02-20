using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket.Responses.OperationResponses
{
    //public class ErrorResponse : OperationResponseBase
    //{
    //    //{"status":400,"error":"Unknown table: tradeBin5dm","meta":{},"request":{"op":"subscribe","args":["tradeBin1m","tradeBin5dm"]}}

    //    [JsonPropertyName("status")]
    //    public double? Status { get; set; }

    //    [JsonPropertyName("error")]
    //    public string? Error { get; set; }

    //    public JsonElement? Meta { get; set; }

    //    internal static bool TryParse(JsonElement response, Action<ErrorResponse> action)
    //    {
    //        if (response.TryGetProperty("error", out _))
    //        {
    //            var errorResponse = BitmexJsonSerializer.Deserialize<ErrorResponse>(response);
    //            action?.Invoke(errorResponse);
    //            return true;
    //        }
    //        return false;
    //    }
    //}
}
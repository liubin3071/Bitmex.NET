using System.Text.Json;
using System.Text.Json.Serialization;
using Bitmex.NET.Dtos.Socket;

namespace Bitmex.NET.Models.Socket.Responses.OperationResponses
{
    public abstract class OperationResponseBase
    {
        //{"success":true,"subscribe":"trade","request":{"op":"subscribe","args":["trade"]}}

        #region error

        //{"status":400,"error":"Unknown table: tradeBin5dm","meta":{},"request":{"op":"subscribe","args":["tradeBin1m","tradeBin5dm"]}}

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("error")]
        public string? Error { get; set; }

        public JsonElement? Meta { get; set; }

        #endregion error

        [JsonPropertyName("request")]
        public InitialRequstInfoDto Request { get; set; }
    }
}
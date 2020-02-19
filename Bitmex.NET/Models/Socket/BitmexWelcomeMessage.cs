using System.Text.Json.Serialization;
using System;

namespace Bitmex.NET.Models.Socket
{
    public class BitmexWelcomeMessage
    {
        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("docs")]
        public string Docs { get; set; }

        [JsonPropertyName("limit")]
        public BitmexWebSocketConnectionLimitMessage Limit { get; set; }
    }
}
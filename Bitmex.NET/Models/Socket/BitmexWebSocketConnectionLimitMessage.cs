using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket
{
    public class BitmexWebSocketConnectionLimitMessage
    {
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }
    }
}

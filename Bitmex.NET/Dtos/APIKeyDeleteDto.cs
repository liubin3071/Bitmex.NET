using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class APIKeyDeleteDto
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
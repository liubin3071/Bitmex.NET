using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos.Socket
{
    public class BitmexSocketOperationResultDto
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("request")]
        public InitialRequstInfoDto Request { get; set; }
    }
}
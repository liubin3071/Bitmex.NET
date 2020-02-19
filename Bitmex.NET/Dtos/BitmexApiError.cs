using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public partial class BitmexApiError
    {
        [JsonPropertyName("error")]
        public Error Error { get; set; }
    }

    public partial class Error
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
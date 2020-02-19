using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class LeaderboardNameDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
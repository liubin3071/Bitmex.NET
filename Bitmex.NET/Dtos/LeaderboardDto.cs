using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class LeaderboardDto
    {
        [JsonPropertyName("profit")]
        public double? Profit { get; set; }

        [JsonPropertyName("isRealName")]
        public bool? IsRealName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
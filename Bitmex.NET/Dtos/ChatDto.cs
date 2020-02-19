using System;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class ChatDto
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; } = null;

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("html")]
        public string Html { get; set; }

        [JsonPropertyName("fromBot")]
        public bool? FromBot { get; set; }

        [JsonPropertyName("channelID")]
        public long? ChannelId { get; set; }
    }

    public class ChatConnectedDto
    {
        [JsonPropertyName("users")]
        public int? Users { get; set; }

        [JsonPropertyName("bots")]
        public int? Bots { get; set; }
    }

    public class ChatChannelDto
    {
        [JsonPropertyName("id")]
        public long? ChannelId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
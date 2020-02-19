using System;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class NotificationDto
    {
        [JsonPropertyName("id")]
        public decimal? Id { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("ttl")]
        public decimal? Ttl { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("closable")]
        public bool? Closable { get; set; }

        [JsonPropertyName("persist")]
        public bool? Persist { get; set; }

        [JsonPropertyName("waitForVisibility")]
        public bool? WaitForVisibility { get; set; }

        [JsonPropertyName("sound")]
        public string Sound { get; set; }
    }
}
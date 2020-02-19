using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class AnnouncementDto
    {
        [JsonPropertyName("id")]
        public decimal? Id { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }
    }
}

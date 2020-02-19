using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class SchemaDto
    {
        [JsonPropertyName("keys")]
        public string[] Keys { get; set; }

        [JsonPropertyName("types")]
        public Dictionary<string, JsonElement> Types { get; set; }
    }

    public class SchemaWebSocketHelpDto
    {
        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("usage")]
        public string Usage { get; set; }

        [JsonPropertyName("ops")]
        public string[] Ops { get; set; }

        [JsonPropertyName("subscribe")]
        public string Subscribe { get; set; }

        [JsonPropertyName("subscriptionSubjects")]
        public Dictionary<string, string[]> SubscriptionSubjects { get; set; }
    }
}
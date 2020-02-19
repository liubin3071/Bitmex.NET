using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos.Socket
{
    [DebuggerDisplay("{" + nameof(TableName) + "} {" + nameof(Action) + "}")]
    public class BitmexSocketDataDto
    {
        [JsonPropertyName("table")]
        public string TableName { get; set; }

        [JsonPropertyName("action")]
        public BitmexActions Action { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JsonElement> AdditionalData { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class InstrumentActiveIntervalsDto
    {
        [JsonPropertyName("intervals")]
        public string[] Intervals { get; set; }

        [JsonPropertyName("symbols")]
        public string[] Symbols { get; set; }
    }
}
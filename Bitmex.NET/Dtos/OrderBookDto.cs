using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public partial class OrderBookDto
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
    }
}
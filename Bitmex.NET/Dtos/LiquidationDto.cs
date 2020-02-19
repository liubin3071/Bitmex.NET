using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class LiquidationDto
    {
        [JsonPropertyName("orderID")]
        public string OrderId { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("leavesQty")]
        public decimal? LeavesQty { get; set; }
    }
}
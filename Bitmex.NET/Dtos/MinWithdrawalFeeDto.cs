using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class MinWithdrawalFeeDto
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("fee")]
        public long? Fee { get; set; }

        [JsonPropertyName("minFee")]
        public long? MinFee { get; set; }
    }
}
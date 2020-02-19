using Bitmex.NET.Models.Socket;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos.Socket
{
    public class InitialRequstInfoDto
    {
        [JsonPropertyName("op")]
        public OperationType? Operation { get; set; }

        [JsonPropertyName("args")]
        public object[] Arguments { get; set; }
    }
}